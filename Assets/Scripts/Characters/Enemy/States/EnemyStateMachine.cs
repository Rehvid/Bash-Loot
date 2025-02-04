namespace RehvidGames.Characters.Enemy.States
{
    using Enums;
    using RehvidGames.States;
    using UnityEngine;
    using Utilities;

    public class EnemyStateMachine: StateMachine<EnemyState>
    {
        [Header("Components")]
        [SerializeField] private Enemy enemy;
        [SerializeField] private EnemyPatrolZone patrolZone;
        [SerializeField] private CooldownTimer cooldownTimer;
        [SerializeField] private EnemySight sight;
        [SerializeField] private EnemyBehaviorSettings behaviorSettings;
        
        private void Awake()
        {
            states.Add(EnemyState.Patrolling, new EnemyPatrolState(enemy, patrolZone, cooldownTimer, behaviorSettings));
            states.Add(EnemyState.Searching, new EnemySearchState(enemy, sight, behaviorSettings, cooldownTimer));
            states.Add(EnemyState.Chasing, new EnemyChaseState(enemy));
            states.Add(EnemyState.Attacking, new EnemyAttackState(enemy));

            currentState = states[EnemyState.Patrolling];
        }

        public void SwitchState(EnemyState newState)
        {
            StateTransition(newState);
        }

        public void SetAnimationTriggerType(AnimationTriggerType triggerType)
        {
            currentState.AnimationTriggerEvent(triggerType);
        }
    }
}