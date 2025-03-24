using System.Collections;
using UnityEngine;

public class PatrollState: BaseState<RunningEnemyBehavoir>
{
    public PatrollState(RunningEnemyBehavoir key, StateManager<RunningEnemyBehavoir> manager, EnemyStats stats, GameObject enemy, MonoBehaviour monoBehavior, LayerMask spellLayer) : base(key, manager)
    {
        _stats = stats;
        _enemy = enemy;
        _manager = manager;
        _behaviour = monoBehavior;
        _spellLayer = spellLayer;
    }

    private EnemyStats _stats;
    private GameObject _enemy;
    private StateManager<RunningEnemyBehavoir> _manager;

    private Vector3 _center;
    
    private float _minX;
    private float _maxX;
    
    private float _minZ;
    private float _maxZ;
    
    private MonoBehaviour _behaviour;
    private LayerMask _spellLayer;
    
    public override void EnterState()
    {
        Debug.Log("Patrolling State");
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
            yield return new WaitForSecondsRealtime(_stats.MoveDelay);
            while (_enemy.transform.position != activePosition)
            {
                _enemy.transform.position = Vector3.MoveTowards(_enemy.transform.position, activePosition, _stats.Speed * Time.deltaTime);
                yield return new WaitForSecondsRealtime(0.01f);
            }
        }
    }
    
    public override void ExitState()
    {
        _behaviour.StopCoroutine(MoveTowardsPoint());
    }

    public override void UpdateState()
    {
        
    }

    public override void OnTriggerEnter(Collider other)
    {
        if ((_spellLayer.value & (1 << other.gameObject.layer)) > 0)
        {
            _manager.TransitionToState(RunningEnemyBehavoir.Run);
        }
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
  