using UnityEngine;

public interface ISpell
{
    public abstract PlayerStats PlayerStats {get; set;}
    public abstract void SpawnFireBall(Transform spawnPoint, Transform target);
}