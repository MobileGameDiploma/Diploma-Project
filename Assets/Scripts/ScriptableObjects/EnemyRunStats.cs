using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy Variation", menuName = "ScriptableObject/EnemyData/RunEnemy")]
public class EnemyRunStats : EnemyStats
{
    [Header("Behavior Addition")]
    public float RunningSpeed;
}