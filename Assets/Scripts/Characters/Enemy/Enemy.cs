namespace RehvidGames.Characters.Enemy
{
    using Enums;
    using States;
    using UnityEngine;
    using Weapon;

    public class Enemy : BaseCharacter
    {
        [Header("Components")]
        [field: SerializeField] public EnemyStateMachine StateMachine { get; private set; }
        [field: SerializeField] public EnemyMovement Movement { get; private set; }
        [field: SerializeField] public Weapon Weapon { get; private set; }

        [Header("Settings")]
        [SerializeField] private EnemyType enemyType;
        
        protected override void HandleDeath()
        {
            StateMachine.SwitchState(EnemyState.Death);
        }
    }
}