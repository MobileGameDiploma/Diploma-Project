using UnityEngine;

public interface ISpellMultipleTargets : ISpell
{
    public abstract void DeleteEnemy(GameObject target);
}