using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemyGroupSpawnSystem : MonoBehaviour
{
    public EnemyHealthSystem EnemyPrefab;
    public List<GameObject> SpawnPoints;
    public float SpawnDelay;

    [Inject] private ObjectPoolService _poolService;
    private Queue<GameObject> _spawnPoints;
    private int _spawnedCount;
    private int _maxCount;

    private void Awake()
    {
        _spawnPoints = new Queue<GameObject>();
        foreach(GameObject spawnPoint in SpawnPoints)
        {
            _spawnPoints.Enqueue(spawnPoint);
        }
        _spawnedCount = 0;
        _maxCount = SpawnPoints.Count;
    }

    private void Start()
    {
        StartCoroutine(SpawnUpdate());
    }

    IEnumerator SpawnUpdate()
    {
        while (true)
        {
            if (_spawnedCount == _maxCount)
            {
                
            }
            else
            {
                EnemyPrefab.EnemyGroupSystem = this;
                GameObject activeSpawnPoint = _spawnPoints.Dequeue();
                GameObject prefab = _poolService.GetOrCreatePool(EnemyPrefab.gameObject).Get();
                prefab.transform.position = activeSpawnPoint.transform.position;
                _spawnPoints.Enqueue(activeSpawnPoint);
                _spawnedCount++;
            }

            yield return new WaitForSeconds(SpawnDelay);
            
        }
    }

    public void EnemyDeath()
    {
        _spawnedCount--;
    }
}
