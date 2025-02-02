namespace RehvidGames.Characters.Player.States
{
    using Animator;
    using Enums;
    using RehvidGames.States;
    using UnityEngine;

    public class PlayerJumpState: BaseState<PlayerState>
    {
        private readonly Player player;
        private readonly float jumpForce;
        private readonly float fallSpeedMultiplier;
        private readonly float defaultGravityScale;
        
        public PlayerJumpState(Player player, float jumpForce, float fallSpeedMultiplier) : base(PlayerState.Jump)
        { 
            this.player = player;
            this.jumpForce = jumpForce;
            this.fallSpeedMultiplier = fallSpeedMultiplier;
            
            defaultGravityScale = player.GravityScale();
        }
        
        public override void EnterState()
        {
            player.SetVelocity(new Vector2(player.RigidBodyVelocity().x , jumpForce)); 
            player.Animator.SetTrigger(MovementAnimatorParameters.Jump);
        }
        
        public override void PhysicsUpdate()
        {
            if (CanApplyFallingForce())
            {
                player.ChangeGravityScale(fallSpeedMultiplier);
            } 
        }
        
        private bool CanApplyFallingForce() => player.RigidBodyVelocity().y < 0;

        public override void ExitState()
        {
            player.ChangeGravityScale(defaultGravityScale);
        }
    }
}