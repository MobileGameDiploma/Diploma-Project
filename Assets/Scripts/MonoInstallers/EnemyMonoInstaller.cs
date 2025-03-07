using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemyMonoInstaller : MonoInstaller
{
    private DiContainer _container;
    private ObjectPoolService _pool;

    public override void InstallBindings()
    {
        BuildObjects();
        InsBindings();
    }


    private void BuildObjects()
    {
        _container = new DiContainer();
        _pool = new ObjectPoolService(new PoolSettings());
    }

    private void InsBindings()
    {
        Container.Bind<ObjectPoolService>().FromInstance(_pool).AsSingle().NonLazy();
    }
}
