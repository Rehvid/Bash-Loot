namespace RehvidGames.Characters.Player.States
{
    using Animator;
    using Enums;
    using RehvidGames.States;
    using UnityEngine;

    public class PlayerBlockState: BaseState<PlayerState>
    {
        private readonly Animator animator;
        
        public PlayerBlockState(Animator animator) : base(PlayerState.Block)
        {
            this.animator = animator;
        }

        public override void EnterState()
        {
           animator.SetTrigger(CombatAnimatorParameters.Block);
        }
        
        public override void ExitState()
        {
            animator.SetBool(CombatAnimatorParameters.IsBlockingIdle, false);
        }
    }
}