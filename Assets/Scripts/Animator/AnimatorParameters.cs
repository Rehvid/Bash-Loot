namespace RehvidGames.Animator
{
    using UnityEngine;
    
    public static class MovementAnimatorParameters
    {
        public static readonly int XVelocity = Animator.StringToHash("xVelocity");
        public static readonly int YVelocity = Animator.StringToHash("yVelocity");
        public static readonly int OnGround = Animator.StringToHash("onGround");
        public static readonly int Jump = Animator.StringToHash("jump");
        public static readonly int Dash = Animator.StringToHash("dash");
    }

    public static class CombatAnimatorParameters
    {
        public static readonly int Attack = Animator.StringToHash("attack");
        public static readonly int Block = Animator.StringToHash("block");
        public static readonly int IsBlockingIdle = Animator.StringToHash("isBlockingIdle");
        public static readonly int Roll = Animator.StringToHash("roll");
        public static readonly int Hit = Animator.StringToHash("hit");
    }

    public static class CharacterAnimatorParameters
    {
        public static readonly int Death = Animator.StringToHash("death");
        public static readonly int IsDeath = Animator.StringToHash("isDeath");
    }
}