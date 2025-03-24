using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy Variation", menuName = "ScriptableObject/EnemyData/PatrolEnemy")]
public class EnemyPatrolStats : EnemyStats
{
    [Header("Behavior Addition")]
    public float RunningSpeed;
    public float DangerMoveDelay;
}