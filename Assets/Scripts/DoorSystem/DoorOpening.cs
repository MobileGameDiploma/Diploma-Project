using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class DoorOpening : MonoBehaviour
{
    [Inject(Id="DoorOpeningDelay")] private float Delay;
    private void Update()
    {
        if(Delay <=0)
            this.enabled = false;
        Delay -= Time.deltaTime;
        
        gameObject.transform.position -= new Vector3(0f,1f,0f) * Time.deltaTime;
    }
}
