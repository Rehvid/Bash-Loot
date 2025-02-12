namespace RehvidGames.Characters.Enemy.States
{
    using Animator;
    using Enums;
    using RehvidGames.States;
    using UnityEngine;

    public class EnemyDeathState: BaseState<EnemyState>
    {
        private readonly Enemy enemy;
        
        public EnemyDeathState(Enemy enemy) : base(EnemyState.Death)
        {
            this.enemy = enemy;
        }

        public override void EnterState()
        {
            enemy.Movement?.StopMovement();
            enemy.Weapon?.DeactivateAttackCollider();
            enemy.Animator?.SetTrigger(CharacterAnimatorParameters.Death);

            DisableCollider();
        }

        private void DisableCollider()
        {
            Collider2D collider2D = enemy.Collider;
            if (collider2D != null)
            {
                collider2D.enabled = false;
            }
        }
    }
}