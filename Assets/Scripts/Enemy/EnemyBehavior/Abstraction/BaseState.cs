using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState<Estate> where Estate : Enum
{
    public BaseState(Estate key, StateManager<Estate> manager)
    {
        StateKey = key;
        _manager = manager;
    }
    
    public Estate StateKey { get; private set; }

    private StateManager<Estate> _manager;
    public abstract void EnterState();
    public abstract void ExitState();
    public abstract void UpdateState();
    public abstract void OnTriggerEnter(Collider other);
    public abstract void OnTriggerStay(Collider other);
    public abstract void OnTriggerExit(Collider other);
}
