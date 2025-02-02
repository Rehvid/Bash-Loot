namespace RehvidGames.Characters.Enemy.States
{
    using Enums;
    using RehvidGames.States;
    
    public class EnemyChaseState: BaseState<EnemyState>
    {
        public EnemyChaseState() : base(EnemyState.Chasing) { }
    }
}