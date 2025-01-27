namespace RehvidGames.Characters.Player.States
{
    using Animator;
    using Enums;
    using RehvidGames.States;
    using UnityEngine;

    public class PlayerWalkState: BaseState<PlayerState>
    {
        private readonly Player player;
        private readonly float speed;
        
        
        public PlayerWalkState(Player player, float speed) : base(PlayerState.Walk)
        {
            this.player = player;
            this.speed = speed;    
        }
        
        public override void PhysicsUpdate()
        {
            player.SetRigidBodyVelocity(new Vector3(player.InputMovement.x, 0, player.InputMovement.y) * speed);
            player.TryUpdateSpriteDirectionHorizontally();
            player.Animator.SetFloat(MovementAnimatorParameters.XVelocity, player.RigidBodyVelocity.magnitude);
        }
    }
}