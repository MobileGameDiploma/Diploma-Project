using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ShopSystemInstaller : MonoInstaller
{
    [Header("Upgrades")]
    public List<int> DamageUpgrades;
    public List<float> SpeedUpgrades;
    public List<float> CastUpgrades;
    [Header("Prices")]
    public List<int> DamageUpgradesPrices;
    public List<int> SpeedUpgradesPrices;
    public List<int> CastSpeedUpgradesPrices;
    
    public override void InstallBindings()
    {
        Container.Bind<List<int>>().WithId("DamageUpgrades").FromInstance(DamageUpgrades).AsCached();
        Container.Bind<List<float>>().WithId("SpeedUpgrades").FromInstance(SpeedUpgrades).AsCached();
        Container.Bind<List<float>>().WithId("CastUpgrades").FromInstance(CastUpgrades).AsCached();
        
        Container.Bind<List<int>>().WithId("DamageUpgradesPrices").FromInstance(DamageUpgradesPrices).AsCached();
        Container.Bind<List<int>>().WithId("SpeedUpgradesPrices").FromInstance(SpeedUpgradesPrices).AsCached();
        Container.Bind<List<int>>().WithId("CastSpeedUpgradesPrices").FromInstance(CastSpeedUpgradesPrices).AsCached();
    }
}
