namespace RehvidGames.Utilities
{
    using UnityEngine;

    public static class AnimatorParameter
    {
        #region Movement
            public static readonly int XVelocity = Animator.StringToHash("xVelocity");
            public static readonly int YVelocity = Animator.StringToHash("yVelocity");
            public static readonly int OnGround = Animator.StringToHash("onGround");
            public static readonly int IsJumping = Animator.StringToHash("isJumping");
        #endregion
    }
}
