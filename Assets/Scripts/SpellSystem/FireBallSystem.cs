using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

public class FireBallSystem : MonoBehaviour, ISpellMultipleTargets
{
    [Inject] 
    public PlayerStats PlayerStats { get; set; }

    public Transform FireBallSpawnPosition;

    [Inject(Id = "EnemyLayer")] 
    private LayerMask _enemyLayer;
    
    private SpellData _currentSpell;
    private List<GameObject> _enemies = new List<GameObject>();

    private void Start()
    {
        _currentSpell = PlayerStats.GetSpellByName("Fireball");
    }

    public void SpawnFireBall(Transform spawnPoint, Transform target)
    {
        GameObject fireball = Instantiate(_currentSpell.VFX_Effect, spawnPoint.position, Quaternion.identity);
        FireBallLogic logic = fireball.GetComponent<FireBallLogic>();
        logic.Target = target;
        logic.System = this;
        StartCoroutine(SpellReload());
    }
    
    public void DeleteEnemy(GameObject target)
    {
        _enemies.Remove(target);
    }
    
    IEnumerator SpellReload()
    {
        _currentSpell.IsActive = true;
        yield return new WaitForSeconds(_currentSpell.CastDelay);
        _currentSpell.IsActive = false;
    }

    private void Update()
    {
        if (_enemies.Count != 0)
        {
            if (!_currentSpell.IsActive)
            {
                SpawnFireBall(FireBallSpawnPosition, _enemies[0].transform);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((_enemyLayer.value & (1 << other.gameObject.layer)) > 0 )
        {
            _enemies.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if ((_enemyLayer.value & (1 << other.gameObject.layer)) > 0 )
        {
            _enemies.Remove(other.gameObject);
        }
    }
}