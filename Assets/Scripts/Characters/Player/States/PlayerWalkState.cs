namespace RehvidGames.Characters.Player.States
{
    using Animator;
    using Contexts;
    using Enums;
    using RehvidGames.States;
    using RehvidGames.States.Interfaces;
    using UnityEngine;

    public class PlayerWalkState: BaseState<PlayerState>
    {
        private readonly Player player;
        private readonly Animator animator;
        private readonly float speed;
        
        private Vector2 inputMovement;
        
        public PlayerWalkState(Animator animator, Player player, float speed) : base(PlayerState.Walk)
        {
            this.animator = animator;
            this.player = player;
            this.speed = speed;    
        }
        
        public override void PhysicsUpdate()
        {
            player.SetRigidBodyVelocity(new Vector3(inputMovement.x, 0, inputMovement.y) * speed);
            
            if (!Mathf.Approximately(inputMovement.x, 0))
            {
                player.FlipSpriteRenderHorizontally(inputMovement.x < 0);
            }
            
            animator.SetFloat(MovementAnimatorParameters.XVelocity, player.RigidBodyVelocity.magnitude);
        }

        public override void InputContext(IContext context)
        {
            if (context is PlayerWalkContext walkContext)
            {
                inputMovement = walkContext.InputMovement;
            }
        }
    }
}