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
        
        public PlayerRollState(Animator animator, Player player, float idleRollForce) : base(PlayerState.Roll)
        {
            this.animator = animator;
            this.player = player;
            this.idleRollForce = idleRollForce;
        }
        
        public override void EnterState()
        {
            if (player.IsStationary())
            {  
                player.AddForceToRigidBody(player.GetIdleDirection() * idleRollForce, ForceMode.Impulse);
            }
            
            animator.SetTrigger(CombatAnimatorParameters.Roll);
        }
        
    }
}