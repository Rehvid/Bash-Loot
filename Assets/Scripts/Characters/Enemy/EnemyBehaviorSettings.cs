namespace RehvidGames.Characters.Enemy
{
    using UnityEngine;

    [CreateAssetMenu(fileName = "EnemyBehaviorSettings", menuName = "Data/Enemy Behavior Settings")]
    public class EnemyBehaviorSettings : ScriptableObject
    {
        [field: SerializeField, Min(0.1f)] public float WaypointTolerance { get; private set; } = 0.1f;
        [field: SerializeField, Min(0.1f)] public float PatrolPauseDuration { get; private set; } = 5f;
        [field: SerializeField, Min(0.1f)] public float SearchStopDistance { get; private set; } = 0.5f;
        [field: SerializeField, Min(0.1f)] public float SearchPauseDuration { get; private set; } = 2f;
    }
}