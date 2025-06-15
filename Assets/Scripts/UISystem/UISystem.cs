using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public class UISystem : MonoBehaviour
{
    [Inject(Id = "InventoryPanel")] private GameObject _inventoryPanel;
    [Inject(Id = "UpgradeShopPanel")] private GameObject _upgradeShopPanel;
    [Inject(Id = "EventPanel")] private GameObject _eventPanel;
    [Inject(Id = "ShopPanel")] private GameObject _shopPanel;
    [Header("Prizes")]
    [Inject(Id = "PrizeWindow")] private GameObject PrizeWindow;
    [Inject(Id = "MagicPointsPrize")] private TextMeshProUGUI MagicPointsPrize;
    [Inject(Id = "ExperiencePointsPrize")] private TextMeshProUGUI ExperiencePointsPrize;
    [Header("Additional")]
    [Inject(Id = "magicPointsText")] private TextMeshProUGUI _magicPointsText;
    [Inject] DoorSystem _doorSystem;
    
    
    public MagicPointsController MagicPointsController;
    
    private void Awake()
    {
        MagicPointsController = new MagicPointsController(_magicPointsText);
    }

    public void OpenInventory()
    {
        _inventoryPanel.SetActive(true);
    }

    public void CloseInventory()
    {
        _inventoryPanel.SetActive(false);
    }

    public void OpenUpgradeShop()
    {
        _upgradeShopPanel.SetActive(true);
    }

    public void CloseUpgradeShop()
    {
        _upgradeShopPanel.SetActive(false);
    }

    public void OpenEventPanel()
    {
        _eventPanel.SetActive(true);
    }

    public void CloseEventPanel()
    {
        _eventPanel.SetActive(false);
    }

    public void OpenGameShop()
    {
        _shopPanel.SetActive(true);
    }

    public void CloseGameShop()
    {
        _shopPanel.SetActive(false);
    }

    public void ActivatePrizeWindow(int magicPointsPrize)
    {
        MagicPointsPrize.text = NumberConverter.INSTANCE.Convert(magicPointsPrize);
    }
    
    public void DisablePrizeWindow()
    {
        PrizeWindow.SetActive(false);
        _doorSystem.OpenDoor();
    }
}
