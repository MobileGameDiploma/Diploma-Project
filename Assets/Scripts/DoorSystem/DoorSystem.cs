using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class DoorSystem : MonoBehaviour
{
    [Inject] private List<DoorOpening> _doors;
    private int _index;

    private void Awake()
    {
        _index = 0;
    }

    public void OpenDoor()
    {
        _doors[_index].enabled = true;
        _index++;
    }
}
