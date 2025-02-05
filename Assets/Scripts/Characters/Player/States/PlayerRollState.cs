namespace RehvidGames.Characters.Player.States
{
    using Animator;
    using Enums;
    using RehvidGames.States;

    public class PlayerRollState: BaseState<PlayerState>
    {
        private readonly Player player;
        private readonly float idleRollForce;
        private readonly float rollForce;
        
        public PlayerRollState(Player player, float idleRollForce, float rollForce) : base(PlayerState.Roll)
        {
            this.player = player;
            this.idleRollForce = idleRollForce;
            this.rollForce = rollForce;
        }
        
        public override void EnterState()
        {
            player.StopWalkingAnimation();
            player.ApplyMovementBasedOnState(player.PhysicsController.IsIdle() ? idleRollForce : rollForce);
            player.Animator.SetTrigger(CombatAnimatorParameters.Roll);
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
            if (triggerType != AnimationTriggerType.RollEnd) return;
            
            player.StateMachine.ResetToIdleIfInState(PlayerState.Roll);
        }
    }
}