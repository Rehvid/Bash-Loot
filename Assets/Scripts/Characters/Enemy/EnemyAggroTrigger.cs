namespace RehvidGames.Characters.Enemy
{
    using Enums;
    using UnityEngine;
    using UnityEngine.Events;

    public class EnemyAggroTrigger: MonoBehaviour
    {
        public UnityEvent<EnemyState> StateChange;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                StateChange?.Invoke(EnemyState.Attacking);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            StateChange?.Invoke(EnemyState.Chasing);
        }
    }
}