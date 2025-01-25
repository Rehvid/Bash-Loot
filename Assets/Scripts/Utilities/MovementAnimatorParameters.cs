namespace RehvidGames.Utilities
{
    using UnityEngine;

    public static class MovementAnimatorParameters
    {
        public static readonly int XVelocity = Animator.StringToHash("xVelocity");
        public static readonly int YVelocity = Animator.StringToHash("yVelocity");
        public static readonly int OnGround = Animator.StringToHash("onGround");
        public static readonly int IsJumping = Animator.StringToHash("isJumping");
        public static readonly int Dash = Animator.StringToHash("dash");
    }

    public static class CombatAnimatorParameters
    {
        public static readonly int Attack = Animator.StringToHash("attack");
    }
}
