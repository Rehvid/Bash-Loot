namespace RehvidGames.Characters.Enemy
{
    using Enums;
    using Player;
    using UnityEngine;
    using UnityEngine.Events;

    public class EnemyAggroTrigger: MonoBehaviour
    {
        public UnityEvent<EnemyState> StateChange;

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
            if (IsPlayerInAggroRange(other))
            {
                StateChange?.Invoke(EnemyState.Attacking);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (!IsPlayerDead())
            {
                StateChange?.Invoke(EnemyState.Chasing);
                return;
            }
            
            StateChange?.Invoke(EnemyState.Patrolling);
        }

        private bool IsPlayerInAggroRange(Collider2D other)
        {
            return other.gameObject == player?.gameObject && !IsPlayerDead();
        }
        
        private bool IsPlayerDead() => player != null && player.IsDead();
    }
}