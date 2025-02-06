namespace RehvidGames.Characters.Player
{
    using Animator;
    using States;
    using UnityEngine;

    public class Player : BaseCharacter
    {
        [Header("Components")]
        [SerializeField] private CharacterSpriteOrientation spriteOrientation;
        [field: SerializeField] public PlayerPhysicsController PhysicsController { get; private set;}
        [field: SerializeField] public PlayerStateMachine StateMachine { get; private set; }


        #region Collider

        public CapsuleCollider2D GetCapsuleCollider()
        {
            return TryGetComponent(out CapsuleCollider2D capsuleCollider) ? capsuleCollider : null;
        }
        #endregion
        
        #region Animations funcitons
        public void StopWalkingAnimation() => Animator.SetFloat(MovementAnimatorParameters.XVelocity, 0);
        #endregion
        
        #region Input movement 
        public Vector2 InputMovement { get; set; }
        
        public bool IsInputMovement() => InputMovement.sqrMagnitude > 0.01f;
        
        public void ClearVelocity() => SetVelocity(Vector2.zero);
        #endregion
        
        #region Sprite Orientation
        public void TryUpdateSpriteDirectionHorizontally() => spriteOrientation.UpdateSpriteDirection(InputMovement);
        
        public float GetIdleVelocityDirection() => spriteOrientation.IsFlippedHorizontally() ? -1f : 1f;
        #endregion
        
        #region Physics Controller
        public Vector2 GetVelocity () => PhysicsController.Rigidbody2D.linearVelocity;
        
        public void SetVelocity(Vector2 velocity) => PhysicsController.SetLinearVelocity(velocity);
        
        public void ApplyMovementBasedOnState(float force)
        {
            if (PhysicsController.IsIdle())
            { 
                PhysicsController.SetIdleVelocity(GetIdleVelocityDirection(), force);
                return;
            }
            
            PhysicsController.ApplyForwardVelocity(force);
        }
        #endregion
    }
}
