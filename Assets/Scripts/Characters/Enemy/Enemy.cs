namespace RehvidGames.Characters.Enemy
{
    using Enums;
    using States;
    using UnityEngine;

    public class Enemy : MonoBehaviour
    {
        [Header("Components")]
        [field: SerializeField] public EnemyStateMachine StateMachine { get; private set; }
        
        [Header("Settings")]
        [SerializeField] private EnemyType enemyType;
    }
}