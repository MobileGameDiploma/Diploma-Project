using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ObjectPoolService
{
    private readonly PoolSettings _defaultSettings;
    private readonly Dictionary<GameObject, GameObjectPool> _poolsMap = new(32);
    private readonly Dictionary<GameObject, GameObject> _spawnedGameObjectsMap = new(256); 

    public IEnumerable<GameObject> SpawnedGameObjects => _spawnedGameObjectsMap.Keys;

    public int SpawnedGameObjectsCount => _spawnedGameObjectsMap.Count;

    public ObjectPoolService(PoolSettings defaultSettings)
    {
        _defaultSettings = defaultSettings;
    }

    public T Spawn<T>(T prefab) where T : Component
    {
        GameObject instance = Spawn(prefab.gameObject);
        return instance.GetComponent<T>();
    }

    public GameObject Spawn(GameObject prefab)
    {
        GameObjectPool pool = GetOrCreatePool(prefab);
        GameObject instance = pool.Get();
        _spawnedGameObjectsMap.Add(instance, prefab);
        return instance;
    }

    public void AddPool(GameObject gameObject,GameObjectPool pool)
    {
        _poolsMap.Add(gameObject, pool);
    }

    public void AddPools(Dictionary<GameObject, GameObjectPool> pools)
    {
        foreach(KeyValuePair<GameObject, GameObjectPool> pair in pools)
        {
            _poolsMap.Add(pair.Key, pair.Value);
        }
    }

    public void Despawn(Component prefab)
    {
        Despawn(prefab.gameObject);
    }

    public void Despawn(GameObject instance)
    {
        GameObject prefab = _spawnedGameObjectsMap[instance];
        GameObjectPool pool = _poolsMap[prefab];
        pool.Release(instance);
        _spawnedGameObjectsMap.Remove(instance);
    }

    public GameObjectPool GetOrCreatePool(GameObject prefab)
    {
        return _poolsMap.TryGetValue(prefab, out GameObjectPool pool) ? pool : CreatePool(prefab);
    }

    public GameObjectPool CreatePool(GameObject prefab, PoolSettings settings = null)
    {
        var newPool = new GameObjectPool(prefab, settings?? _defaultSettings);
        _poolsMap.Add(prefab, newPool);
        return newPool;
    }
}