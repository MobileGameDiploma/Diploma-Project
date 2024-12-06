using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSystem : MonoBehaviour
{
    [HideInInspector] public GameObject Target;
    public LayerMask EnemyLayer;

    
    private void OnTriggerEnter(Collider other)
    {
        if (EnemyLayer >> other.gameObject.layer == 1)
        {
            Target = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Target)
        {
            Target = null;
        }
    }
}
