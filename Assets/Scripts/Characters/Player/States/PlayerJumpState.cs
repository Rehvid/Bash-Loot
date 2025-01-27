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
        
        public PlayerJumpState(Player player, float jumpForce, float fallSpeedMultiplier) : base(PlayerState.Jump)
        {
            this.player = player;
            this.jumpForce = jumpForce;
            this.fallSpeedMultiplier = fallSpeedMultiplier;
        }
        
        public override void EnterState()
        {
            player.AddForceToRigidBody(Vector3.up * jumpForce, ForceMode.Impulse); 
            player.Animator.SetTrigger(MovementAnimatorParameters.Jump);
        }
        
        public override void PhysicsUpdate()
        {
            if (CanApplyFallingForce())
            {
                ApplyFallingForce();
            }
        }
        
        private bool CanApplyFallingForce() => player.RigidBodyVelocity.y < 0;
        
        private void ApplyFallingForce() => player.AddForceToRigidBody(Vector3.down * fallSpeedMultiplier, ForceMode.Acceleration);
    }
}