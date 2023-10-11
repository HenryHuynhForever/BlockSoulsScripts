using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractionInterface : MonoBehaviour
{
    private TMP_Text interactionName;
	
	private void Start(){
		interactionName = transform.Find("Interaction Name").GetComponent<TMP_Text>();
		gameObject.SetActive(false);
	}
	
	public void ChangeInteractionName(string name){
		interactionName.text = name;
	}
}
