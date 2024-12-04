using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementSystem : MonoBehaviour
{
    public EnemyGroupSpawnSystem EnemyGroupSpawnSystem;
    public float Speed = 2;
    public float MoveDelay = 4;
    public List<Transform> MovePoints;

    private void Start()
    {
        
    }

    IEnumerator MoveTowardsPoint()
    {
        while (true)
        {


            return new WaitForSecondsRealtime(MoveDelay);
        }
    }
}
