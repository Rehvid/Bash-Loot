namespace RehvidGames.Characters.Enemy.States
{
    using Animator;
    using Enums;
    using Player;
    using RehvidGames.States;
    using UnityEngine;

    public class EnemyAttackState: BaseState<EnemyState>
    {
        private readonly Enemy enemy;
        private readonly Player player;
        
        private AttackStateType attackStateType  = AttackStateType.Ready;
        
        public EnemyAttackState(Enemy enemy) : base(EnemyState.Attacking)
        {
            this.enemy = enemy;
            
            GameObject.FindGameObjectWithTag("Player").TryGetComponent(out player);
        }

        public override void EnterState()
        {
            enemy.Movement.StopMovement();
        }

        public override void FrameUpdate()
        {
            if (!IsReady()) return;
            
            if (IsPlayerDead())
            {
                enemy.StateMachine.SwitchState(EnemyState.Patrolling);
                return;
            }
            
            Attack();
        }

        private bool IsPlayerDead()
        {
            return player && player.IsDead();
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

        private bool IsReady() => attackStateType == AttackStateType.Ready;
    }
}