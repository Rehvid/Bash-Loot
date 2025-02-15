﻿namespace RehvidGames.Characters.Player.States
{
    using Animator;
    using Enums;
    using RehvidGames.States;
    using UnityEngine;

    public class PlayerBlockState: BaseState<PlayerState>
    {
        private readonly Player player;
        
        public PlayerBlockState(Player player) : base(PlayerState.Block)
        {
            this.player = player;
        }
        
        public override void EnterState()
        {
            player.PhysicsController.Rigidbody2D.bodyType = RigidbodyType2D.Kinematic;
            player.ClearVelocity();
            player.StopWalkingAnimation();
            player.Animator.SetTrigger(CombatAnimatorParameters.Block);
        }

        public override void PhysicsUpdate()
        {
            player.TryUpdateSpriteDirectionHorizontally();
        }

        public override void AnimationTriggerEvent(AnimationTriggerType triggerType)
        {
            if (triggerType != AnimationTriggerType.BlockIdle) return;
            
            if (player.StateMachine.IsInState(PlayerState.Block))
            {
                SetIsBlockingIdle(true);
            }
        }

        public override void ExitState()
        {
            player.PhysicsController.Rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
            SetIsBlockingIdle(false);
        }

        private void SetIsBlockingIdle(bool isBlocking)
        {
            player.Animator.SetBool(CombatAnimatorParameters.IsBlockingIdle, isBlocking);
        }
    }
}