using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemyMovementSystem : MonoBehaviour
{
    public float Speed = 2;
    public float MoveDelay = 4;
    [Inject(Id = "StandartLength")]
    public float Length;
    
    private Vector3 _center;
    
    private float _minX;
    private float _maxX;
    
    private float _minZ;
    private float _maxZ;
    
    
    private void Start()
    {
        _center = gameObject.transform.position;
        
        _minX = _center.x - Length;
        _maxX = _center.x + Length;
        _minZ = _center.z - Length;
        _maxZ = _center.z + Length;
        
        StartCoroutine(MoveTowardsPoint());
    }

    IEnumerator MoveTowardsPoint()
    {
        Vector3 activePosition;
        while (true)
        {
            activePosition = GetRandomPoint();
            yield return new WaitForSecondsRealtime(MoveDelay);
            while (transform.position != activePosition)
            {
                transform.position = Vector3.MoveTowards(transform.position, activePosition, Speed * Time.deltaTime);
                yield return new WaitForSecondsRealtime(0.01f);
            }
        }
    }

    private Vector3 GetRandomPoint()
    {
        return new Vector3(Random.Range(_minX, _maxX), transform.position.y, Random.Range(_minZ, _maxZ));
    }
}
