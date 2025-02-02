namespace RehvidGames.Characters.Player
{
    using States;
    using UnityEngine;

    public class Player : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private CharacterSpriteOrientation spriteOrientation;
        [SerializeField] private CharacterPhysicsController physicsController;
        
        [field: SerializeField] public PlayerStateMachine StateMachine { get; private set; }
        [field: SerializeField] public Animator Animator { get; private set; }
        
        #region Input movement 
        public Vector2 InputMovement { get; set; }
        
        public bool IsInputMovement() => InputMovement.sqrMagnitude > 0.01f;
        #endregion
        
        #region Sprite Orientation
        public void TryUpdateSpriteDirectionHorizontally() => spriteOrientation.UpdateSpriteDirection(InputMovement);
        
        public float GetIdleDirection() => spriteOrientation.IsFlippedHorizontally() ? -1f : 1f;
        
        #endregion
        
        #region Physics Controller

        public Rigidbody2D Rigidbody() => physicsController.rb;
        
        public float GravityScale() => physicsController.GravityScale;
        
        public void ChangeGravityScale (float scale) => physicsController.ChangeGravityScale(scale);
        
        public Vector2 RigidBodyVelocity () => physicsController.LinearVelocity;
        
        public void SetVelocity(Vector2 velocity) => physicsController.SetLinearVelocity(velocity);

        public bool IsStationary() => Mathf.Approximately(RigidBodyVelocity().normalized.magnitude, 0f);
        
        public void AddForceToRigidBody(Vector2 force, ForceMode2D mode) => physicsController.AddForce(force, mode);
        
        #endregion
    }
}
