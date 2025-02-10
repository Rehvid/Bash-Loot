namespace RehvidGames.Characters
{
    using Attributes;
    using UnityEngine;

    public class CharacterStats : MonoBehaviour
    {
        [field: SerializeField] public FloatAttribute Health { get; set; } = new ();

        public void TakeDamage(float damageTaken)
        {
            Health.SetCurrentValue(Health.CurrentValue - damageTaken);
        }
        
        public bool IsDead() => Health.CurrentValue <= 0;
    }
}