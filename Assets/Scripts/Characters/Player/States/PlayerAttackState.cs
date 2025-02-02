namespace RehvidGames.Characters.Player.States
{
    using Enums;
    using RehvidGames.States;

    public class PlayerAttackState: BaseState<PlayerState>
    {
        private readonly Player player;

        public PlayerAttackState(Player player) : base(PlayerState.Attack)
        {
            this.player = player;
        }
    }
}