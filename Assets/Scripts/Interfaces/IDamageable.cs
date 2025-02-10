namespace RehvidGames.Interfaces
{
    public interface IDamageable
    {
        public void TakeDamage(float damage);
        public bool CanTakeDamage(float damage);
    }
}

