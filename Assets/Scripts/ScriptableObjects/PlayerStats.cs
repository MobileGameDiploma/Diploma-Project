using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName = "Player/Stats")]
public class PlayerStats : ScriptableObject
{
    [Header("Player Parameters")]
    public float Health;
    public float Speed;
    public float Defence;
    public float Armor;

    [Header("Multipliers")]
    public float DamageMultiplyParameter;
    public float CastSpeedMultiplyParameter;

    [Header("Spells")]
    public List<SpellInfo> Spells;
}
