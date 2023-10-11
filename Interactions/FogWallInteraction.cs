using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogWallInteraction : MonoBehaviour
{
    public void OnActivated(){
		gameObject.SetActive(false);
	}
	
	public void OnExited(){
		gameObject.SetActive(true);
	}
}
