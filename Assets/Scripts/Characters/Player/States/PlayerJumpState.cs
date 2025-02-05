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
            
            defaultGravityScale = player.PhysicsController.Rigidbody2D.gravityScale;
        }
        
        public override void EnterState()
        {
            player.SetVelocity(new Vector2(player.GetVelocity().x , jumpForce)); 
            player.Animator.SetTrigger(MovementAnimatorParameters.Jump);
        }
        
        public override void PhysicsUpdate()
        {
            if (CanApplyFallingForce())
            {
                ChangeGravityScale(fallSpeedMultiplier);
            } 
        }
        
        private bool CanApplyFallingForce() => player.GetVelocity().y < 0;

        public override void ExitState()
        {
            ChangeGravityScale(defaultGravityScale);
            if (!player.IsInputMovement())
            {
                player.StopWalkingAnimation();
            }
        }
        
        private void ChangeGravityScale(float gravityScale) => player.PhysicsController.ChangeGravityScale(gravityScale);
    }
}