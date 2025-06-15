using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SystemsInstaller : MonoInstaller
{
    public LootSystem LootSystem;
    public LevelSystem LevelSystem;
    public UISystem UISystem;
    public DoorSystem DoorSystem;

    public override void InstallBindings()
    {
        Container.Bind<LootSystem>().FromInstance(LootSystem).AsCached();
        Container.Bind<LevelSystem>().FromInstance(LevelSystem).AsCached();
        Container.Bind<UISystem>().FromInstance(UISystem).AsCached();
        Container.Bind<DoorSystem>().FromInstance(DoorSystem).AsCached();
    }
}
