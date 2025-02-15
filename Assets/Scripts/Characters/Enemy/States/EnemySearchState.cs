﻿namespace RehvidGames.Characters.Enemy.States
{
    using Enums;
    using RehvidGames.States;
    using UnityEngine;
    using Utilities;

    public class EnemySearchState: BaseState<EnemyState>
    {
        private readonly Enemy enemy;
        private readonly EnemySight enemySight;
        private readonly EnemyBehaviorSettings behaviorSettings;
        private readonly CooldownTimer cooldownTimer;
        
        private bool hasTargetReached;
        
        public EnemySearchState(
            Enemy enemy, 
            EnemySight enemySight, 
            EnemyBehaviorSettings behaviorSettings,
            CooldownTimer cooldownTimer
        ) : base(EnemyState.Searching)
        {
            this.enemy = enemy;
            this.enemySight = enemySight;
            this.behaviorSettings = behaviorSettings;
            this.cooldownTimer = cooldownTimer;
        }

        public override void EnterState()
        {
            enemy.Movement.Direction = (LastPlayerPosition() - enemy.GetPosition()).normalized;
            hasTargetReached = false;
        }
 
        public override void FrameUpdate()
        {
            if (!IsTargetReached()) return;

            if (!hasTargetReached)
            {
                SetHasTargetReached();
                return;
            }

            if (cooldownTimer.HasElapsed(behaviorSettings.SearchPauseDuration))
            {
                SwitchStateIfIsNotDetected();
            }
        }

        private bool IsTargetReached()
        {
            return enemy.Movement.IsTargetReached(LastPlayerPosition(), behaviorSettings.SearchStopDistance);
        }

        private void SetHasTargetReached()
        {
            hasTargetReached = true;
            cooldownTimer.Reset();
            enemy.Movement.StopMovement();
        }

        private void SwitchStateIfIsNotDetected()
        {
            if (!enemySight.DetectionResult.IsPlayerDetected)
            {
                enemy.StateMachine.SwitchState(EnemyState.Patrolling);
            }
        }
        
        private Vector2 LastPlayerPosition() => new(enemySight.LastPlayerPosition.x, enemySight.LastPlayerPosition.y);

        public override void ExitState()
        { 
            cooldownTimer.Reset();
            enemy.Movement.ResumeMovement();
            enemySight.LastPlayerPosition = Vector2.negativeInfinity;
        }
    }
}