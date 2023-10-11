using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerCamera : MonoBehaviour
{
    private Transform cameraTarget;
    private Transform myCamera;

    private float rotateX;

    public void Awake()
    {
        cameraTarget = transform.Find("CameraTarget");
        myCamera = cameraTarget.Find("Camera");
    }

    public void ProcessCamera(Vector2 input)
    {
        cameraTarget.position = transform.position + (Vector3.up * 0.75f);
        myCamera.position = cameraTarget.position + -(myCamera.forward * 2.0f);

        float inputX = input.y * 50.0f * Time.deltaTime;
        float inputY = input.x * 50.0f * Time.deltaTime;

        rotateX -= inputX;
        rotateX = Mathf.Clamp(rotateX, -60.0f, 60.0f);

        myCamera.localRotation = Quaternion.Euler(rotateX, 0.0f, 0.0f);

        cameraTarget.Rotate(0.0f, inputY, 0.0f);
    }
}
