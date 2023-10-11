using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/*

A very hacky way of making the lever rotate.

*/

public class LeverInteractionScript : MonoBehaviour
{
    private Transform myLever;

    private void Awake()
    {
        myLever = transform.Find("Lever");
    }

    public void OnInteractionInvoke(){
		if (myLever.localRotation == Quaternion.Euler(0.0f, 0.0f, 30.0f)){
			myLever.localRotation = Quaternion.Euler(0.0f, 0.0f, -30.0f);
		}else{
			myLever.localRotation = Quaternion.Euler(0.0f, 0.0f, 30.0f);
		}
	}
}
