namespace RehvidGames.Characters.Player.States
{
    using Animator;
    using Enums;
    using RehvidGames.States;
    using UnityEngine;

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
            player.Animator.SetFloat(MovementAnimatorParameters.XVelocity, 0);
            
            if (player.IsStationary())
            { 
                player.SetVelocity(new Vector2(player.GetIdleDirection()* idleDashForce , player.RigidBodyVelocity().y));
            }
            else
            {
                player.Rigidbody().position += new Vector2(dashForce * Time.fixedDeltaTime, 0);
            }
            
            player.Animator.SetTrigger(MovementAnimatorParameters.Dash);
        }
    }
}