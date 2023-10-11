using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerMovement : MonoBehaviour
{
    private CharacterController myCharacterController;
    private Transform cameraTarget;
    private Transform myBody;
    private Animator myAnimator;

    private bool isGrounded;
    private bool isBlocking;
    private bool isAttacking;
    private bool isRolling;

    private Vector3 velocity;
    private float gravity = 9.8f;
    private float speed = 1.0f;
    public float walkSpeed = 4.0f;
    public float blockingSpeed = 2.0f;

    private void Awake()
    {
        myCharacterController = GetComponent<CharacterController>();
        cameraTarget = transform.Find("CameraTarget");
        myBody = transform.Find("Body");
        myAnimator = myBody.GetComponent<Animator>();
    }

    private void Update()
    {
        isGrounded = myCharacterController.isGrounded;
        isBlocking = myAnimator.GetBool("isBlocking");
        isAttacking = myAnimator.GetBool("isAttacking");
        isRolling = myAnimator.GetBool("isRolling");

        if (isBlocking == true)
        {
            speed = blockingSpeed;
        }
        else if (isBlocking == false)
        {
            speed = walkSpeed;
        }
    }

    public void ProcessMovement(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;

        if (isGrounded)
        {
            velocity.y = -2.0f;
        }
        else
        {
            velocity.y -= gravity * Time.deltaTime;
        }
        myCharacterController.Move(velocity * Time.deltaTime);

        if (input.magnitude > 0 && isAttacking == false && isRolling == false)
        {
            myAnimator.SetBool("isWalking", true);
            
            myCharacterController.Move(cameraTarget.TransformDirection(moveDirection) * speed * Time.deltaTime);
            RotateCharacter(moveDirection);
        }
        else if (isAttacking == false && isRolling == true)
        {
            myCharacterController.Move(myBody.TransformDirection(Vector3.forward) * 4.0f * Time.deltaTime);
        }
        else if (input.magnitude == 0)
        {
            myAnimator.SetBool("isWalking", false);
        }
    }

    private void RotateCharacter(Vector3 moveDirection)
    {
        Quaternion targetRotation = Quaternion.LookRotation(cameraTarget.TransformDirection(moveDirection), Vector3.up);
        myBody.localRotation = Quaternion.Lerp(myBody.localRotation, targetRotation, 10.0f * Time.deltaTime);
    }
}
