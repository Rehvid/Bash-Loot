namespace RehvidGames.Characters.Enemy
{
    using Enums;
    using States;
    using UnityEngine;

    public class Enemy : MonoBehaviour
    {
        [Header("Components")]
        [field: SerializeField] public EnemyStateMachine StateMachine { get; private set; }
        [field: SerializeField] public EnemyMovement Movement { get; private set; }
        [field: SerializeField] public Animator Animator { get; private set; }
        
        [Header("Settings")]
        [SerializeField] private EnemyType enemyType;

        public void SetAnimationTriggerType(AnimationTriggerType triggerType)
        {
            StateMachine.SetAnimationTriggerType(triggerType);
        }
        
        public Vector2 GetPosition() => new (transform.position.x, transform.position.y);
    }
}