namespace RehvidGames.Characters.Enemy
{
    using Enums;
    using States;
    using UnityEngine;

    public class Enemy : BaseCharacter
    {
        [Header("Components")]
        [field: SerializeField] public EnemyStateMachine StateMachine { get; private set; }
        [field: SerializeField] public EnemyMovement Movement { get; private set; }
        
        [Header("Settings")]
        [SerializeField] private EnemyType enemyType;
    }
}