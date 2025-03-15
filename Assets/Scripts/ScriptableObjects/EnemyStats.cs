using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy Data", menuName = "ScriptableObject/EnemyData")]
public class EnemyStats : ScriptableObject
{
    public string ID;
    public float Health;
}