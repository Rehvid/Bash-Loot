namespace RehvidGames.Characters.Player.States
{
    using Enums;
    using RehvidGames.States;

    public class PlayerIdleState: BaseState<PlayerState>
    {
        public PlayerIdleState() : base(PlayerState.Idle) { }
    }
}