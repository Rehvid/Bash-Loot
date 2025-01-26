namespace RehvidGames.Characters.Player.States
{
    using Animator;
    using Enums;
    using RehvidGames.States;
    using UnityEngine;

    public class PlayerAttackState: BaseState<PlayerState>
    {
        private readonly Animator animator;

        public PlayerAttackState(Animator animator) : base(PlayerState.Attack)
        {
            this.animator = animator;
        }

        public override void EnterState()
        {
            animator.SetTrigger(CombatAnimatorParameters.Attack);
        }
    }
}