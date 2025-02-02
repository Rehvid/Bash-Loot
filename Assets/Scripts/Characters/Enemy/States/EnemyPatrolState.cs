namespace RehvidGames.Characters.Enemy.States
{
    using Enums;
    using RehvidGames.States;

    public class EnemyPatrolState: BaseState<EnemyState>
    {
        public EnemyPatrolState() : base(EnemyState.Patrolling)
        {
          
        }
    }
}