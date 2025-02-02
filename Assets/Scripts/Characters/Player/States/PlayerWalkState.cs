namespace RehvidGames.Characters.Player.States
{
    using Enums;
    using RehvidGames.States;

    public class PlayerWalkState: BaseState<PlayerState>
    {
        private readonly Player player;
        private readonly float speed;
        
        
        public PlayerWalkState(Player player, float speed) : base(PlayerState.Walk)
        {
            this.player = player;
            this.speed = speed;    
        }

    }
}