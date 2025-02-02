namespace RehvidGames.Characters.Player.States
{
    using Animator;
    using Enums;
    using RehvidGames.States;
    using UnityEngine;

    public class PlayerBlockState: BaseState<PlayerState>
    {
        private readonly Player player;
        
        public PlayerBlockState(Player player) : base(PlayerState.Block)
        {
            this.player = player;
        }
        
        public override void EnterState()
        { 
            player.SetVelocity(Vector2.zero);
            player.Animator.SetFloat(MovementAnimatorParameters.XVelocity, 0);
            player.Animator.SetTrigger(CombatAnimatorParameters.Block);
        }

        public override void PhysicsUpdate()
        {
            player.TryUpdateSpriteDirectionHorizontally();
        }

        public override void ExitState()
        {
            player.Animator.SetBool(CombatAnimatorParameters.IsBlockingIdle, false);
        }
    }
}