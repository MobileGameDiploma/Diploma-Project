using UnityEngine;

public class RunState : BaseState<RunningEnemyBehavoir>
{
    public RunState(RunningEnemyBehavoir key, StateManager<RunningEnemyBehavoir> manager, EnemyHealthSystem healthSystem, EnemyRunStats runStats, GameObject player, GameObject enemy) : base(key, manager)
    {
        _manager = manager;
        _healthSystem = healthSystem;
        _stats = runStats;
        _player = player;
        _enemy = enemy;
    }

    private StateManager<RunningEnemyBehavoir> _manager;
    private EnemyHealthSystem _healthSystem;
    private EnemyRunStats _stats;
    
    private GameObject _player;
    private GameObject _enemy;
    
    public override void EnterState()
    {
        
    }

    public override void ExitState()
    {
        
    }

    public override void UpdateState()
    {
        Vector3 directionAwayFromPlayer = (_enemy.transform.position - _player.transform.position).normalized;

        // Calculate the new position to move towards
        Vector3 newPosition = _enemy.transform.position + directionAwayFromPlayer * _stats.RunningSpeed * Time.deltaTime;

        // Move the enemy to the new position
        _enemy.transform.position = newPosition;
        
        if(!_healthSystem.IsTarget)
        {
            _manager.TransitionToState(RunningEnemyBehavoir.Patrol);
        }
    }
    
    public override void OnTriggerEnter(Collider other)
    {
        
    }

    public override void OnTriggerStay(Collider other)
    {
        
    }

    public override void OnTriggerExit(Collider other)
    {
        
    }
}