using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/*
The general script for all interactions to extend from.
*/

public class GeneralInteraction : MonoBehaviour
{
    // Variables
	private GameObject interactionUI;
	private InteractionInterface interactionInterface;
    private PlayerInput playerInput;
	
	// Public Variables
	public string interactionName;
    public UnityEvent onActivated = new UnityEvent(); // Multiple functions can be connected to a unity event.
	public UnityEvent onEntered = new UnityEvent();
	public UnityEvent onExited = new UnityEvent();

    private void Start()
    {
        Transform player = GameObject.Find("Player").transform;
		interactionUI = GameObject.Find("User Interface").transform.Find("Interaction UI").gameObject;
		interactionInterface = interactionUI.GetComponent<InteractionInterface>();
		
		// This is so the player can activate the interaction.
        playerInput = player.GetComponent<PlayerInput>();
        playerInput.playerActions.Interact.performed += ctx => OnInteractPerformed();
    }

    private void OnTriggerEnter(Collider other)
    {
		if (other.tag == "Player"){
			interactionInterface.ChangeInteractionName(interactionName);
			interactionUI.SetActive(true);
			onEntered.Invoke();
		}
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player"){
			interactionUI.SetActive(false);
			onExited.Invoke();
		}
    }

    private void OnInteractPerformed()
    {
        if (interactionUI.activeSelf == true)
        {
            onActivated.Invoke(); // Invoke all connected functions.
        }
    }
}
