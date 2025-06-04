using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class UIMonoInstaller : MonoInstaller
{
    public GameObject InventoryPanel;
    public GameObject UpgradeShopPanel;
    public GameObject EventPanel;
    public GameObject ShopPanel;

    public override void InstallBindings()
    {
        Container.Bind<GameObject>().WithId("InventoryPanel").FromInstance(InventoryPanel).AsCached();
        Container.Bind<GameObject>().WithId("UpgradeShopPanel").FromInstance(UpgradeShopPanel).AsCached();
        Container.Bind<GameObject>().WithId("EventPanel").FromInstance(EventPanel).AsCached();
        Container.Bind<GameObject>().WithId("ShopPanel").FromInstance(ShopPanel).AsCached();
    }
}
