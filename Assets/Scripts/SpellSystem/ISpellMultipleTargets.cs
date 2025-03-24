using UnityEngine;

public interface ISpellMultipleTargets : ISpell
{
    public abstract void AddTarget(GameObject target);
    public abstract void RemoveTarget(GameObject target);
}