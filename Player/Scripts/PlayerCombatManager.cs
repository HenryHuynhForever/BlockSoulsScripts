using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatManager : MonoBehaviour
{
    private Transform myBody;
    private Animator myAnimator;

    private PlayerInput myPlayerInput;

    public float playerStamina = 100.0f;
    public float maxStamina = 100.0f;
    public float staminaRegeneration = 8.0f;
    private float weaponStaminaCost = 20.0f;

    private bool isRolling;
    private bool isAttacking;

    private void Awake()
    {
        myBody = transform.Find("Body");
        myAnimator = myBody.GetComponent<Animator>();
    }
	
	private void Start(){
		myPlayerInput = GetComponent<PlayerInput>();

        myPlayerInput.playerActions.MouseLeft.started += ctx => OnLeftButtonStarted();
        myPlayerInput.playerActions.MouseLeft.canceled += ctx => OnLeftButtonEnded();
        myPlayerInput.playerActions.MouseRight.started += ctx => OnRightButtonStarted();
        myPlayerInput.playerActions.MouseRight.canceled += ctx => OnRightButtonEnded();
        myPlayerInput.playerActions.Space.performed += ctx => OnRollPerformed();
	}

    private void Update()
    {
        isRolling = myAnimator.GetBool("isRolling");
        isAttacking = myAnimator.GetBool("isAttacking");
        
        playerStamina += staminaRegeneration * Time.deltaTime;
        playerStamina = Mathf.Clamp(playerStamina, 0.0f, maxStamina);
    }

    private void OnLeftButtonStarted()
    {
        if (playerStamina >= weaponStaminaCost && myAnimator.GetBool("isAttacking") == false && myAnimator.GetBool("isBlocking") == false)
        {
            myAnimator.SetBool("isWalking", false);
            myAnimator.SetBool("isAttacking", true);
            playerStamina -= weaponStaminaCost;
        }
    }

    private void OnLeftButtonEnded()
    {
        
    }

    private void OnRightButtonStarted()
    {
        myAnimator.SetBool("isBlocking", true);
    }

    private void OnRightButtonEnded()
    {
        myAnimator.SetBool("isBlocking", false);
    }

    private void OnRollPerformed()
    {
        if (isRolling == false && isAttacking == false && playerStamina >= 10.0f)
        {
            myAnimator.SetBool("isWalking", false);
            myAnimator.SetBool("isRolling", true);
            playerStamina -= 10.0f;
        }
    }
}
