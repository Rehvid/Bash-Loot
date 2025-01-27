namespace RehvidGames.Characters.Player.Contexts
{
    using RehvidGames.States.Interfaces;
    using UnityEngine;

    public class PlayerWalkContext: IContext
    {
        public Vector2 InputMovement { get; set; }

        public bool IsInputMovement() => InputMovement.sqrMagnitude > 0.01f;
    }
}