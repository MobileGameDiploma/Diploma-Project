using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class View : MonoBehaviour
{
    [Inject(Id = "InventoryPanel")] private GameObject _inventoryPanel;
    [Inject(Id = "UpgradeShopPanel")] private GameObject _upgradeShopPanel;
    [Inject(Id = "EventPanel")] private GameObject _eventPanel;
    [Inject(Id = "ShopPanel")] private GameObject _shopPanel;
    
    
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
}
