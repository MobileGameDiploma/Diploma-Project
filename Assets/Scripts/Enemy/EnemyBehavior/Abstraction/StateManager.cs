using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class StateManager<Estate> : MonoBehaviour where Estate : Enum
{
    public EnemyHealthSystem HealthSystem;
    protected Dictionary<Estate, BaseState<Estate>> States = new Dictionary<Estate, BaseState<Estate>>();
    
    protected BaseState<Estate> CurrentState;

    void Start()
    {
        AddStates();
        SetSceneUp();
        CurrentState.EnterState();
    }
    
    void Update()
    {
        CurrentState.UpdateState();
    }

    public abstract void SetSceneUp();
    public abstract void AddStates();

    public void TransitionToState(Estate stateKey)
    {
        CurrentState.ExitState();
        CurrentState = States[stateKey];
        CurrentState.EnterState();
    }

    private void OnDisable()
    {
        CurrentState.ExitState();
    }

    private void OnTriggerEnter(Collider other)
    {
        CurrentState.OnTriggerEnter(other);
    }

    private void OnTriggerStay(Collider other)
    {
        CurrentState.OnTriggerStay(other);
    }

    private void OnTriggerExit(Collider other)
    {
        CurrentState.OnTriggerExit(other);
    }
}