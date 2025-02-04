namespace RehvidGames.Characters.Player.States
{
    using Animator;
    using Enums;
    using RehvidGames.States;
    using UnityEngine;

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
            player.Animator.SetFloat(MovementAnimatorParameters.XVelocity, 0);
            
            if (player.IsIdle())
            {  
                player.PhysicsController.ApplyIdleForce(player.GetIdleVelocityDirection(), idleRollForce);
            }
            else
            {
                player.PhysicsController.ApplyForwardMovement(rollForce);
            } 
            
            player.Animator.SetTrigger(CombatAnimatorParameters.Roll);
        }

        public override void ExitState()
        {
            if (!player.IsIdle())
            {
                player.SetVelocity(new Vector2(0, 0));
            }
        }

        public override void AnimationTriggerEvent(AnimationTriggerType triggerType)
        {
            if (triggerType != AnimationTriggerType.RollEnd) return;
            
            player.StateMachine.ResetToIdleIfInState(PlayerState.Roll);
        }
    }
}