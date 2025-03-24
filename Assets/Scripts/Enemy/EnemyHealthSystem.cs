using System;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

public class EnemyHealthSystem : MonoBehaviour
{
    public EnemyStats EnemyStats;
    public EnemyGroupSpawnSystem EnemyGroupSystem;
    public bool IsTarget = false;
    [Inject] ObjectPoolService _objectPoolService;
    [Inject(Id = "SpellSystemsLayer")] LayerMask _spellSystemsLayer;
    private float _health;

    private void Awake()
    {
        _health = EnemyStats.Health;
    }

    public void DealDamage(float damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            _objectPoolService.GetOrCreatePool(gameObject).Release(gameObject);
            EnemyGroupSystem.EnemyDeath();
        }
    }
    
    public void DealDamage(float damage, ISpellMultipleTargets spellSystem)
    {
        _health -= damage;
        if (_health <= 0)
        {
            spellSystem.RemoveTarget(gameObject);
            IsTarget = false;
            _objectPoolService.GetOrCreatePool(gameObject).Release(gameObject);
            EnemyGroupSystem.EnemyDeath();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((_spellSystemsLayer.value & (1 << other.gameObject.layer)) > 0)
        {
            ISpellMultipleTargets multSpell = other.GetComponent<ISpellMultipleTargets>();
            multSpell?.AddTarget(gameObject);
            IsTarget = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if ((_spellSystemsLayer.value & (1 << other.gameObject.layer)) > 0)
        {
            ISpellMultipleTargets multSpell = other.GetComponent<ISpellMultipleTargets>();
            multSpell?.RemoveTarget(gameObject);
            IsTarget = false;
        }
    }
}