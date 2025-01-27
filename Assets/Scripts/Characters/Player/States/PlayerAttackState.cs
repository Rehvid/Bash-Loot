namespace RehvidGames.Characters.Player.States
{
    using Animator;
    using Enums;
    using RehvidGames.States;
    using UnityEngine;

    public class PlayerAttackState: BaseState<PlayerState>
    {
        private readonly Animator animator;
        private readonly Player player;

        public PlayerAttackState(Animator animator, Player player) : base(PlayerState.Attack)
        {
            this.animator = animator;
            this.player = player;
        }

        public override void EnterState()
        {
            animator.SetTrigger(CombatAnimatorParameters.Attack);
            animator.SetFloat(MovementAnimatorParameters.XVelocity, 0);
        }

        public override void PhysicsUpdate()
        {
            player.TryFlipSpriteRenderHorizontally();
        }
    }
}