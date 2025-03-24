using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemyMovement : MonoBehaviour
{
    public EnemyStats Stats;
    
    private Vector3 _center;
    
    private float _minX;
    private float _maxX;
    
    private float _minZ;
    private float _maxZ;
    
    
    private void Start()
    {
        _center = gameObject.transform.position;
        
        _minX = _center.x - Stats.Length;
        _maxX = _center.x + Stats.Length;
        _minZ = _center.z - Stats.Length;
        _maxZ = _center.z + Stats.Length;
        
        StartCoroutine(MoveTowardsPoint());
    }

    IEnumerator MoveTowardsPoint()
    {
        Vector3 activePosition;
        while (true)
        {
            activePosition = GetRandomPoint();
            yield return new WaitForSecondsRealtime(Stats.MoveDelay);
            while (transform.position != activePosition)
            {
                transform.position = Vector3.MoveTowards(transform.position, activePosition, Stats.Speed * Time.deltaTime);
                yield return new WaitForSecondsRealtime(0.01f);
            }
        }
    }

    private Vector3 GetRandomPoint()
    {
        return new Vector3(Random.Range(_minX, _maxX), transform.position.y, Random.Range(_minZ, _maxZ));
    }
}
