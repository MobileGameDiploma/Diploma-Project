using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class FireBallLogic : MonoBehaviour
{
    public List<GameObject> Visuals;
    public Transform Target;
    public FireBall System;
    
    [Inject]
    private PlayerStats _playerStats;
    [Inject]
    private ObjectPoolService _poolService;
    [Inject(Id = "AudioSourceExample")]
    private AudioSource _audioSource;
    [Inject(Id = "EnemyLayer")]
    private LayerMask _enemyLayer;
    
    
    private SpellData _currentSpell;
    private GameObjectPool _audioPool;
    
    private void Start()
    {
        Debug.Log(_audioSource);
        _currentSpell = _playerStats.GetSpellByName("Fireball");
        _audioPool = _poolService.GetOrCreatePool(_audioSource.gameObject);
        MakeSound(_currentSpell.ActivationSound);
        StartCoroutine(MoveTowards());
    }
    
    IEnumerator MoveTowards()
    {
        while (true)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, Target.position,
                _currentSpell.CastSpeed * Time.deltaTime);
            yield return new WaitForSeconds(0.001f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((_enemyLayer.value & (1 << other.gameObject.layer)) > 0)
        {
            Debug.Log(LayerMask.LayerToName(other.gameObject.layer));
            StartCoroutine(DestroyFireBall(other.gameObject));
        }
    }

    

    IEnumerator DestroyFireBall(GameObject enemy)
    {
        MakeSound(_currentSpell.DeactivationSound);
        enemy.GetComponent<EnemyHealthSystem>().DealDamage(_currentSpell.Damage, System);
        Invisible();
        yield return new WaitForSeconds(_currentSpell.DeactivationSound.length);
        Destroy(gameObject);
    }

    private void Invisible()
    {
        foreach (GameObject visual in Visuals)
        {
            visual.SetActive(false);
        }
    }
    private void MakeSound(AudioClip clip)
    {
        AudioSource audioSource = _audioPool.Get().GetComponent<AudioSource>();
        audioSource.clip = clip;
        audioSource.Play();
    }
}