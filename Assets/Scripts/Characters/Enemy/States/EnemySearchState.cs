namespace RehvidGames.Characters.Enemy.States
{
    using Enums;
    using RehvidGames.States;

    public class EnemySearchState: BaseState<EnemyState>
    {
        public EnemySearchState() : base(EnemyState.Searching)
        {
         
        } 

    }
}