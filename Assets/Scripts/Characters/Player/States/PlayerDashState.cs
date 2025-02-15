﻿namespace RehvidGames.Characters.Player.States
{
    using Animator;
    using Enums;
    using RehvidGames.States;

    public class PlayerDashState: BaseState<PlayerState>
    {
        private readonly Player player;
        private readonly float dashForce;
        private readonly float idleDashForce;
        
        public PlayerDashState(Player player, float dashForce, float idleDashForce) : base(PlayerState.Dash)
        {
            this.player = player;
            this.dashForce = dashForce;
            this.idleDashForce = idleDashForce;
        }
        
        public override void EnterState()
        {
            player.StopWalkingAnimation();
            player.ApplyMovementBasedOnState(player.PhysicsController.IsIdle() ? idleDashForce : dashForce);
            player.Animator.SetTrigger(MovementAnimatorParameters.Dash);
        }

        public override void ExitState()
        {
            if (!player.PhysicsController.IsIdle())
            {
                player.ClearVelocity();
            }
        }
        
        public override void AnimationTriggerEvent(AnimationTriggerType triggerType)
        {
            if (triggerType != AnimationTriggerType.DashEnd) return;

            player.StateMachine.ResetToIdleIfInState(PlayerState.Dash);
        }
    }
}