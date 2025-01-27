namespace RehvidGames.Characters.Player.States
{
    using Animator;
    using Enums;
    using RehvidGames.States;
    using UnityEngine;

    public class PlayerRollState: BaseState<PlayerState>
    {
        private readonly Animator animator;
        private readonly Player player;
        private readonly float idleRollForce;
        private readonly float rollForce;
        
        public PlayerRollState(Animator animator, Player player, float idleRollForce, float rollForce) : base(PlayerState.Roll)
        {
            this.animator = animator;
            this.player = player;
            this.idleRollForce = idleRollForce;
            this.rollForce = rollForce;
        }
        
        public override void EnterState()
        {
            animator.SetFloat(MovementAnimatorParameters.XVelocity, 0);
            
            if (player.IsStationary())
            {  
                player.AddForceToRigidBody( player.GetIdleDirection() * idleRollForce, ForceMode.Impulse);
            }
            else
            {
                player.AddForceToRigidBody(player.RigidBodyVelocity * rollForce, ForceMode.Acceleration);
            } 
            
            animator.SetTrigger(CombatAnimatorParameters.Roll);
        }
        
    }
}