using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Spells", menuName ="Speels/SpellInfo")]
public class SpellInfo : ScriptableObject
{
    public float Damage;
    public float CastSpeed;
    public float CritChance;
    public float CritMultiplier;


}
