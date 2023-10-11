using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIManager : MonoBehaviour
{
    public PlayerCombatManager myCombatManager;
    
    private Transform selectionPanel;
    private Transform inventoryPanel;

    private Transform playerStats;
    private Transform healthBar;
    private Transform magicBar;
    private Transform staminaBar;

    private bool isSelectionActive = false;

    private void Awake()
    {        
        selectionPanel = transform.Find("Selection");
        inventoryPanel = transform.Find("Inventory");

        playerStats = transform.Find("Player Stats");
        healthBar = playerStats.Find("Health Bar");
        magicBar = playerStats.Find("Magic Bar");
        staminaBar = playerStats.Find("Stamina Bar");

        selectionPanel.gameObject.SetActive(false);
        inventoryPanel.gameObject.SetActive(false);
    }

    public void Update()
    {
        PlayerHUD();
    }

    public void EnableUI()
    {
        inventoryPanel.gameObject.SetActive(true);
    }

    public void DisableUI()
    {
        inventoryPanel.gameObject.SetActive(false);
    }

    public void OnUIActivate()
    {
        isSelectionActive = !isSelectionActive;
        
        if (isSelectionActive == true)
        {
            selectionPanel.gameObject.SetActive(true);
        }
        else if (isSelectionActive == false)
        {
            selectionPanel.gameObject.SetActive(false);
        }
    }

    private void PlayerHUD()
    {
        float mainWidth = playerStats.GetComponent<RectTransform>().rect.width;

        RectTransform staminaTransform = staminaBar.GetComponent<RectTransform>();
        float staminaWidth = (myCombatManager.playerStamina / myCombatManager.maxStamina) * mainWidth;
        staminaTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, staminaWidth);
        staminaTransform.ForceUpdateRectTransforms();
    }
}
