using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public class UIMonoInstaller : MonoInstaller
{
    [Header("Panels")]
    public GameObject InventoryPanel;
    public GameObject UpgradeShopPanel;
    public GameObject EventPanel;
    public GameObject ShopPanel;
    [Header("Prizes")]
    public GameObject PrizeWindow;
    public TextMeshProUGUI MagicPointsPrize;
    public TextMeshProUGUI ExperiencePointsPrize;
    [Header("Additional")]
    public TextMeshProUGUI MagicPointsText;
    public UIData UIData;

    public override void InstallBindings()
    {
        Container.Bind<GameObject>().WithId("InventoryPanel").FromInstance(InventoryPanel).AsCached();
        Container.Bind<GameObject>().WithId("UpgradeShopPanel").FromInstance(UpgradeShopPanel).AsCached();
        Container.Bind<GameObject>().WithId("EventPanel").FromInstance(EventPanel).AsCached();
        Container.Bind<GameObject>().WithId("ShopPanel").FromInstance(ShopPanel).AsCached();
        Container.Bind<UIData>().FromInstance(UIData).AsCached();
    }
}
