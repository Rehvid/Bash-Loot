namespace RehvidGames.Characters.Player.States
{
    using Animator;
    using Enums;
    using RehvidGames.States;
    using UnityEngine;

    public class PlayerDashState: BaseState<PlayerState>
    {
        private readonly Animator animator;
        private readonly Player player;
        private readonly float dashForce;
        
        public PlayerDashState(Animator animator, Player player, float dashForce) : base(PlayerState.Dash)
        {
            this.animator = animator;
            this.player = player;
            this.dashForce = dashForce;
        }

        public override void EnterState()
        {
            Vector3 force = player.IsStationary() ? player.GetIdleDirection() : player.RigidBodyVelocity;
            
            player.AddForceToRigidBody(force * dashForce, ForceMode.Impulse);
            animator.SetTrigger(MovementAnimatorParameters.Dash);
        }
    }
}