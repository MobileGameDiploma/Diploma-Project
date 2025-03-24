using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy Data", menuName = "ScriptableObject/EnemyData/BasicEnemy")]
public class EnemyStats : ScriptableObject
{
    [Header("Enemy Parameters")]
    public float Health;
    
    [Header("Movement Parameters")]
    public float Speed;
    public float Length;
    public float MoveDelay;
}