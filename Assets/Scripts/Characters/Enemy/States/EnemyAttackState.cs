namespace RehvidGames.Characters.Enemy.States
{
    using Animator;
    using Enums;
    using RehvidGames.States;

    public class EnemyAttackState: BaseState<EnemyState>
    {
        private readonly Enemy enemy;
        
        private AttackStateType attackStateType  = AttackStateType.Ready;
        
        public EnemyAttackState(Enemy enemy) : base(EnemyState.Attacking)
        {
            this.enemy = enemy;
        }

        public override void EnterState()
        {
            enemy.Movement.StopMovement();
        }

        public override void FrameUpdate()
        {
            if (attackStateType != AttackStateType.Attacking)
            {
                Attack();
            }
        }

        private void Attack()
        {
            enemy.Animator.SetTrigger(CombatAnimatorParameters.Attack);
            attackStateType = AttackStateType.Attacking;
        }
        
        public override void ExitState()
        {
            ResetAttackStateType();
            enemy.Movement.ResumeMovement();
        }

        public override void AnimationTriggerEvent(AnimationTriggerType triggerType)
        {
            switch (triggerType)
            {
                case AnimationTriggerType.AttackEnd:
                    ResetAttackStateType();
                    break;
                case AnimationTriggerType.ActivateAttackCollider:
                    enemy.Weapon.ActivateAttackCollider();
                    break;
                case AnimationTriggerType.DeactivateAttackCollider:
                    enemy.Weapon.DeactivateAttackCollider();
                    break;
            }
        }

        private void ResetAttackStateType() => attackStateType = AttackStateType.Ready;
    }
}