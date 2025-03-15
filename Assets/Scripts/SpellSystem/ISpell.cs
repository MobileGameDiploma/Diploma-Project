using UnityEngine;

public interface ISpell
{
    public abstract PlayerStats PlayerStats {get; set;}
    public abstract void Execute(Transform spawnPoint, Transform target);
}