namespace RehvidGames.Characters.Player.States
{
    using Animator;
    using Enums;
    using RehvidGames.States;
    using Weapon;

    public class PlayerAttackState: BaseState<PlayerState>
    {
        private readonly Player player;
        private readonly Weapon weapon;
        
        public PlayerAttackState(Player player, Weapon weapon) : base(PlayerState.Attack)
        {
            this.player = player;
            this.weapon = weapon;
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
            switch (triggerType)
            {
                case AnimationTriggerType.AttackEnd:
                    player.StateMachine.ResetToIdleIfInState(PlayerState.Attack);
                    break;
                case AnimationTriggerType.ActivateAttackCollider:
                    weapon.ActivateAttackCollider();
                    break;
                case AnimationTriggerType.DeactivateAttackCollider:
                    weapon.DeactivateAttackCollider();
                    break;
            }
        }
    }
}