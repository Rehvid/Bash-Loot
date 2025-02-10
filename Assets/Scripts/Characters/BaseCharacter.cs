namespace RehvidGames.Characters
{
    using Interfaces;
    using UnityEngine;

    public abstract class BaseCharacter: MonoBehaviour, IDamageable
    {
        [Header("Character components")]
        [field: SerializeField] public Animator Animator { get; protected set; }

        [SerializeField] protected CharacterStats characterStats;
        
        public Vector2 GetPosition() => new (transform.position.x, transform.position.y);

        public virtual void TakeDamage(float damage)
        {
            characterStats.TakeDamage(damage);
        }

        public virtual bool CanTakeDamage(float damage)
        {
            return !characterStats.IsDead(); 
        }
        
        public bool IsDead() => characterStats.IsDead();
    }
}