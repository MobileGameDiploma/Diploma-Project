using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class DoorSystemInstaller : MonoInstaller
{
    public List<DoorOpening> Doors;
    public float Delay;

    public override void InstallBindings()
    {
        Container.Bind<float>().WithId("DoorOpeningDelay").FromInstance(Delay).AsCached();
        Container.Bind<List<DoorOpening>>().FromInstance(Doors).AsCached();
    }
}
