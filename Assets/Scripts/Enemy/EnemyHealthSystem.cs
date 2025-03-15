using System;
using UnityEngine;
using Zenject;

public class EnemyHealthSystem : MonoBehaviour
{
    public EnemyStats EnemyStats;
    [Inject] ObjectPoolService _objectPoolService;
    private float _health;

    private void Awake()
    {
        _health = EnemyStats.Health;
    }

    public void DealDamage(float damage)
    {
        _health -= damage;
        Debug.Log(_health);
        if (_health <= 0)
        {
            _objectPoolService.GetOrCreatePool(gameObject).Release(gameObject);
        }
    }
    
    public void DealDamage(float damage, ISpellMultipleTargets spellSystem)
    {
        _health -= damage;
        Debug.Log(_health);
        if (_health <= 0)
        {
            spellSystem.DeleteEnemy(this.gameObject);
            _objectPoolService.GetOrCreatePool(gameObject).Release(gameObject);
        }
    }
}