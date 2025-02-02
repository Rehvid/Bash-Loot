namespace RehvidGames.Characters.Player.States
{
    using Enums;
    using RehvidGames.States;

    public class PlayerBlockState: BaseState<PlayerState>
    {
        private readonly Player player;
        
        public PlayerBlockState(Player player) : base(PlayerState.Block)
        {
            this.player = player;
        }
    }
}