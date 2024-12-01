using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroupSpawnSystem : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public List<GameObject> SpawnPoints;
    public float SpawnDelay;

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
                GameObject activeSpawnPoint = _spawnPoints.Dequeue();
                Instantiate(EnemyPrefab, activeSpawnPoint.transform.position, Quaternion.identity);
                _spawnPoints.Enqueue(activeSpawnPoint);
                _spawnedCount++;
            }

            yield return new WaitForSeconds(SpawnDelay);
        }
    }
}
