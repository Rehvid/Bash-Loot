namespace RehvidGames.Characters.Enemy
{
    using Enums;
    using Player;
    using UnityEngine;

    public class EnemyAggroTrigger: MonoBehaviour
    {
        [Header("Components")] 
        [SerializeField] private Enemy enemy;
        
        private Player player;
        
        private void Start()
        {
            var gamePlayer = GameObject.FindGameObjectWithTag("Player");
            if (gamePlayer == null || !gamePlayer.TryGetComponent(out player))
            {
                Debug.LogError("Player not found");
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (IsPlayerInAggroRange(other) && !enemy.StateMachine.IsInState(EnemyState.Death))
            {
                enemy.StateMachine.SwitchState(EnemyState.Attacking);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (enemy.StateMachine.IsInState(EnemyState.Death)) return;
            
            if (!IsPlayerDead())
            {
                enemy.StateMachine.SwitchState(EnemyState.Chasing);
                return;
            }
            
            enemy.StateMachine.SwitchState(EnemyState.Patrolling);
        }

        private bool IsPlayerInAggroRange(Collider2D other)
        {
            return other.gameObject == player?.gameObject && !IsPlayerDead();
        }
        
        private bool IsPlayerDead() => player != null && player.IsDead();
    }
}