namespace RehvidGames.Weapon
{
    using Interfaces;
    using UnityEngine;

    public class Weapon : MonoBehaviour
    {
        [Header("Components")] 
        [SerializeField] private Collider2D hitCollider;
        
        [Header("Settings")]
        [SerializeField] private WeaponStats weaponStats;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            float damageToDeal = weaponStats.Damage;
            if (other.gameObject.TryGetComponent(out IDamageable damageable) && damageable.CanTakeDamage(damageToDeal))
            {
                damageable.TakeDamage(damageToDeal);
            }
        }

        public void ActivateAttackCollider()
        {
            hitCollider.isTrigger = true;
        }

        public void DeactivateAttackCollider()
        {
            hitCollider.isTrigger = false;
        }

    }
}