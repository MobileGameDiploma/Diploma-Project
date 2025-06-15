using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

public class ScriptableInstaller : ScriptableObjectInstaller
{
    public LootSystem lootSystem;

    public override void InstallBindings()
    {
        Container.Bind<LootSystem>().FromInstance(lootSystem).AsCached();
    }
}
