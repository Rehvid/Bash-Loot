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
        private readonly float defaultGravityScale;
       
        
        public PlayerRollState(Player player, float idleRollForce, float rollForce) : base(PlayerState.Roll)
        {
            this.player = player;
            this.idleRollForce = idleRollForce;
            this.rollForce = rollForce;
            
            defaultGravityScale = player.PhysicsController.Rigidbody2D.gravityScale;
        }
        
        public override void EnterState()
        {
            player.StopWalkingAnimation();
            player.ApplyMovementBasedOnState(player.PhysicsController.IsIdle() ? idleRollForce : rollForce);
            player.Animator.SetTrigger(CombatAnimatorParameters.Roll);
            
            ChangeGravityScale(0);
            SetTriggerCollider(true);
        }

        public override void ExitState()
        {
            ChangeGravityScale(defaultGravityScale);
            SetTriggerCollider(false);
            
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
        
        private void ChangeGravityScale(float gravityScale) => player.PhysicsController.ChangeGravityScale(gravityScale);
        
        private void SetTriggerCollider(bool isTrigger) => player.GetCapsuleCollider().isTrigger = isTrigger;
    }
}