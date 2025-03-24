using UnityEngine;
using Zenject;

public class PatrolRunManager : StateManager<PatrolEnemyBehavoir>
{
    public GameObject CurrentEnemy;
    
    public EnemyPatrolStats Stats;

    [Inject(Id = "SpellLayer")] private LayerMask _spellLayer;

    public override void SetSceneUp()
    {
        CurrentState = States[PatrolEnemyBehavoir.Patrolling];
    }

    public override void AddStates()
    {
        PatrollingState patrollingState = 
            new PatrollingState(PatrolEnemyBehavoir.Patrolling, this, Stats, CurrentEnemy, this, _spellLayer);
        PatrolRunningState patrolRunningState =
            new PatrolRunningState(PatrolEnemyBehavoir.PatrolRunning, this, Stats, CurrentEnemy, this, _spellLayer, HealthSystem);
        States.Add(PatrolEnemyBehavoir.Patrolling, patrollingState);
        States.Add(PatrolEnemyBehavoir.PatrolRunning, patrolRunningState);
    }
}