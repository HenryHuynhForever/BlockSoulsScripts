using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private InputMaster inputMaster;
    public InputMaster.PlayerActions playerActions;

    private NewPlayerMovement playerMovement;
    private NewPlayerCamera playerCamera;
    private PlayerUIManager playerUIManager;

    public bool isCursorLocked = true;

    private void Awake()
    {
        inputMaster = new InputMaster();
        playerActions = inputMaster.Player;

        playerMovement = GetComponent<NewPlayerMovement>();
        playerCamera = GetComponent<NewPlayerCamera>();
        playerUIManager = GameObject.Find("User Interface").GetComponent<PlayerUIManager>();

        playerActions.Inventory.performed += ctx => OnInventoryPerformed();

        Cursor.lockState = CursorLockMode.Locked;
    }

    private void FixedUpdate()
    {
        playerMovement.ProcessMovement(playerActions.Move.ReadValue<Vector2>());
    }

    private void LateUpdate()
    {
        playerCamera.ProcessCamera(playerActions.Look.ReadValue<Vector2>());
    }

    private void OnInventoryPerformed()
    {
        isCursorLocked = !isCursorLocked;

        if (isCursorLocked == true)
        {
            Cursor.lockState = CursorLockMode.Locked;
            playerUIManager.DisableUI();
        }
        if (isCursorLocked == false)
        {
            Cursor.lockState = CursorLockMode.None;
            playerUIManager.EnableUI();
        }
    }

    private void OnEnable()
    {
        playerActions.Enable();
    }

    private void OnDisable()
    {
        playerActions.Disable();
    }
}
