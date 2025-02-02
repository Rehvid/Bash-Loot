namespace RehvidGames.Characters.Player.States
{
    using Enums;
    using RehvidGames.States;

    public class PlayerJumpState: BaseState<PlayerState>
    {
        private readonly Player player;
        private readonly float jumpForce;
        private readonly float fallSpeedMultiplier;
        
        public PlayerJumpState(Player player, float jumpForce, float fallSpeedMultiplier) : base(PlayerState.Jump)
        {
            this.player = player;
            this.jumpForce = jumpForce;
            this.fallSpeedMultiplier = fallSpeedMultiplier;
        }
    }
}