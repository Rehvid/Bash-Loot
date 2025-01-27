namespace RehvidGames.Characters.Player.States
{
    using Animator;
    using Enums;
    using RehvidGames.States;
    using UnityEngine;

    public class PlayerBlockState: BaseState<PlayerState>
    {
        private readonly Animator animator;
        private readonly Player player;
        
        public PlayerBlockState(Animator animator, Player player) : base(PlayerState.Block)
        {
            this.player = player;
            this.animator = animator;
        }

        public override void EnterState()
        { 
            player.SetRigidBodyVelocity(Vector3.zero);
            animator.SetFloat(MovementAnimatorParameters.XVelocity, 0);
            
            animator.SetTrigger(CombatAnimatorParameters.Block);
        }

        public override void PhysicsUpdate()
        {
            player.TryFlipSpriteRenderHorizontally();
        }

        public override void ExitState()
        {
            animator.SetBool(CombatAnimatorParameters.IsBlockingIdle, false);
        }
    }
}