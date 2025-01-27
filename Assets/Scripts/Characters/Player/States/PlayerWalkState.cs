namespace RehvidGames.Characters.Player.States
{
    using Animator;
    using Enums;
    using RehvidGames.States;
    using UnityEngine;

    public class PlayerWalkState: BaseState<PlayerState>
    {
        private readonly Player player;
        private readonly Animator animator;
        private readonly float speed;
        
        
        public PlayerWalkState(Animator animator, Player player, float speed) : base(PlayerState.Walk)
        {
            this.animator = animator;
            this.player = player;
            this.speed = speed;    
        }
        
        public override void PhysicsUpdate()
        {
            Vector2 inputMovement = player.WalkContext.InputMovement; 
             
            player.SetRigidBodyVelocity(new Vector3(inputMovement.x, 0, inputMovement.y) * speed);
            player.TryFlipSpriteRenderHorizontally();
            
            animator.SetFloat(MovementAnimatorParameters.XVelocity, player.RigidBodyVelocity.magnitude);
        }

        public override void ExitState()
        {
            animator.SetFloat(MovementAnimatorParameters.XVelocity, 0);
        }
    }
}