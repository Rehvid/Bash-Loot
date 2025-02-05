namespace RehvidGames.Characters.Player.States
{
    using Animator;
    using Enums;
    using RehvidGames.States;

    public class PlayerAttackState: BaseState<PlayerState>
    {
        private readonly Player player;

        public PlayerAttackState(Player player) : base(PlayerState.Attack)
        {
            this.player = player;
        }
        
        public override void EnterState()
        {
            player.StopWalkingAnimation();
            player.Animator.SetTrigger(CombatAnimatorParameters.Attack);
        }

        public override void PhysicsUpdate()
        {
            player.TryUpdateSpriteDirectionHorizontally();
        }

        public override void AnimationTriggerEvent(AnimationTriggerType triggerType)
        {
            if (triggerType != AnimationTriggerType.AttackEnd) return;

            player.StateMachine.ResetToIdleIfInState(PlayerState.Attack);
        }
    }
}