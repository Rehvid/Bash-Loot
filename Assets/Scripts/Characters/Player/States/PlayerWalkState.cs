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
            player.SetVelocity(new Vector2(player.InputMovement.x, 0) * speed);
            player.TryUpdateSpriteDirectionHorizontally();
            player.Animator.SetFloat(MovementAnimatorParameters.XVelocity, player.RigidBodyVelocity().magnitude);
        }
    }
}