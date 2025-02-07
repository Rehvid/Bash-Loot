namespace RehvidGames.Characters
{
    using Interfaces;
    using UnityEngine;

    public abstract class BaseCharacter: MonoBehaviour, IDamageable
    {
        [Header("Character components")]
        [field: SerializeField] public Animator Animator { get; protected set; }
        
        public Vector2 GetPosition() => new (transform.position.x, transform.position.y);

        public void TakeDamage(float damage)
        {
            Debug.Log($"Damage taken: {damage}, gameObject {gameObject.name}");
        }
    }
}