using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemyMonoInstaller : MonoInstaller
{
    [Header("Небольшая зона передвижения")]
    public float SmallLength;
    [Header("Нормальная зона передвижения")]
    public float StandartLength;
    [Header("Слой врагов")]
    public LayerMask EnemyLayer;
    [Header("Слой магических навыков")] 
    public LayerMask SpellLayer;
    [Header("Слой систем магических навыков")] 
    public LayerMask SpellSystemsLayer;
    
    private GameObjectPoolFactory _poolFactory;
    private ObjectPoolService _pool;

    public override void InstallBindings()
    {
        BuildObjects();
        InsBindings();
    }


    private void BuildObjects()
    {
        _pool = new ObjectPoolService(new PoolSettings());
    }

    private void InsBindings()
    {
        Container.Bind<ObjectPoolService>().FromInstance(_pool).AsSingle().NonLazy();
        Container.Bind<float>().WithId("SmallLength").FromInstance(SmallLength).AsCached().NonLazy();
        Container.Bind<float>().WithId("StandartLength").FromInstance(StandartLength).AsCached().NonLazy();
        Container.Bind<LayerMask>().WithId("EnemyLayer").FromInstance(EnemyLayer).AsCached().NonLazy();
        Container.Bind<LayerMask>().WithId("SpellLayer").FromInstance(SpellLayer).AsCached().NonLazy();
        Container.Bind<LayerMask>().WithId("SpellSystemsLayer").FromInstance(SpellSystemsLayer).AsCached().NonLazy();
        
    }
}
