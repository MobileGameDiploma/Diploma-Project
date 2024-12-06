using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementSystem : MonoBehaviour
{
    public float Speed = 2;
    public float MoveDelay = 4;
    public List<Transform> MovePoints;
    private int _index = 0;

    private void Start()
    {
        StartCoroutine(MoveTowardsPoint());
    }

    IEnumerator MoveTowardsPoint()
    {
        while (true)
        {
            Transform activePoint = MovePoints[_index];

            yield return new WaitForSecondsRealtime(MoveDelay);

            while (transform.position != activePoint.position)
            {
                transform.position = Vector3.MoveTowards(transform.position, activePoint.position, Speed);
                yield return new WaitForSecondsRealtime(0.01f);
            }
            if (_index == MovePoints.Count - 1)
                _index = 0;
            else
                _index++;
        }
    }
}
