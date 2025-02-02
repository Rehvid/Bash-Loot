namespace RehvidGames.Characters.Enemy.States
{
    using Enums;
    using RehvidGames.States;

    public class EnemyAttackState: BaseState<EnemyState>
    {
        public EnemyAttackState() : base(EnemyState.Attacking) { }
    }
}