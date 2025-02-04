namespace RehvidGames.Characters.Enemy.States
{
    using Enums;
    using RehvidGames.States;
    using UnityEngine;
    using Utilities;

    public class EnemyPatrolState: BaseState<EnemyState>
    {
        private readonly Enemy enemy;
        private readonly EnemyPatrolZone patrolZone;
        private readonly CooldownTimer cooldownTimer;
        private readonly EnemyBehaviorSettings behaviorSettings;
        
        private Vector2 currentTarget;
        
        public EnemyPatrolState(
            Enemy enemy,
            EnemyPatrolZone patrolZone,
            CooldownTimer cooldownTimer,
            EnemyBehaviorSettings behaviorSettings
        ) : base(EnemyState.Patrolling) 
        {
            this.enemy = enemy;
            this.patrolZone = patrolZone;
            this.cooldownTimer = cooldownTimer;
            this.behaviorSettings = behaviorSettings;
        }

        public override void EnterState()
        {
            enemy.Movement.SetMovementSpeed();
            cooldownTimer.ResetFixed();
            
            SelectNextTarget();
        }

        private void SelectNextTarget()
        {
            Vector2 randomPatrolPoint = patrolZone.GetRandomPatrolPoint();
            
            if (currentTarget == randomPatrolPoint)
            {
                randomPatrolPoint = patrolZone.GetRandomPatrolPoint();
            }
            
            currentTarget = randomPatrolPoint;
            enemy.Movement.Direction = GetDirectionToTarget();
        }

        private Vector2 GetDirectionToTarget()
        {
            var currentEnemyPosition = new Vector2(enemy.transform.position.x, enemy.transform.position.y);
            return (currentTarget - currentEnemyPosition).normalized;
        }
        
        public override void PhysicsUpdate()
        {
            if (!IsTargetReached()) return;
            enemy.Movement.StopMovement();
            
            TryStartNewPatrol();
        }

        private void TryStartNewPatrol()
        {
            if (cooldownTimer.HasElapsedFixed(behaviorSettings.PatrolPauseDuration))
            {
                StartNewPatrol();
            }
        }
        
        private void StartNewPatrol()
        {
            SelectNextTarget();
            enemy.Movement.ResumeMovement();
            cooldownTimer.ResetFixed(); 
        }

        private bool IsTargetReached()
        {
            return enemy.Movement.IsTargetReached(currentTarget, behaviorSettings.WaypointTolerance);
        }


        public override void ExitState()
        {
            cooldownTimer.ResetFixed();
            enemy.Movement.ResumeMovement();
        }
    }
}