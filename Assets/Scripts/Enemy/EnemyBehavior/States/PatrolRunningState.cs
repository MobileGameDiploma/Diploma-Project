using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PatrolRunningState : BaseState<PatrolEnemyBehavoir>
{
    public PatrolRunningState(PatrolEnemyBehavoir key, StateManager<PatrolEnemyBehavoir> manager, EnemyPatrolStats stats, GameObject enemy, MonoBehaviour monoBehavior, LayerMask spellLayer, EnemyHealthSystem healthSystem) : base(key, manager)
    {
        _stats = stats;
        _enemy = enemy;
        _manager = manager;
        _healthSystem = healthSystem;
        _behaviour = monoBehavior;
        _spellLayer = spellLayer;
    }
    
    private EnemyPatrolStats _stats;
    private EnemyHealthSystem _healthSystem;
    private GameObject _enemy;

    private Vector3 _center;
    
    private float _minX;
    private float _maxX;
    
    private float _minZ;
    private float _maxZ;
    
    private MonoBehaviour _behaviour;
    private StateManager<PatrolEnemyBehavoir> _manager;
    private LayerMask _spellLayer;
    public override void EnterState()
    {
        Debug.Log("Patrol Running");
        _center = _enemy.transform.position;
        
        _minX = _center.x - _stats.Length;
        _maxX = _center.x + _stats.Length;
        _minZ = _center.z - _stats.Length;
        _maxZ = _center.z + _stats.Length;

        _behaviour.StartCoroutine(MoveTowardsPoint());
    }

    IEnumerator MoveTowardsPoint()
    {
        Vector3 activePosition;
        while (true)
        {
            activePosition = GetRandomPoint(_enemy.transform);
            yield return new WaitForSecondsRealtime(_stats.DangerMoveDelay);
            while (_enemy.transform.position != activePosition)
            {
                _enemy.transform.position = Vector3.MoveTowards(_enemy.transform.position, activePosition, _stats.RunningSpeed * Time.deltaTime);
                yield return new WaitForSecondsRealtime(0.0001f);
            }
        }
    }
    
    public override void ExitState()
    {
        _behaviour.StopCoroutine(MoveTowardsPoint());
    }

    public override void UpdateState()
    {
        if (!_healthSystem.IsTarget)
        {
            _manager.TransitionToState(PatrolEnemyBehavoir.Patrolling);
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
    
    private Vector3 GetRandomPoint(Transform enemyTransform)
    {
        return new Vector3(Random.Range(_minX, _maxX), enemyTransform.position.y, Random.Range(_minZ, _maxZ));
    }
}