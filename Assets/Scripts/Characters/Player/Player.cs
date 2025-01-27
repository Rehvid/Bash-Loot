namespace RehvidGames.Characters.Player
{
    using Characters;
    using States;
    using UnityEngine;

    public class Player : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private CharacterSpriteOrientation spriteOrientation;
        [SerializeField] private CharacterPhysicsController physicsController;
        [field: SerializeField] public PlayerStateMachine StateMachine { get; private set; }
        [field: SerializeField] public Animator Animator { get; private set; }
        
        
        public Vector2 InputMovement { get; set; }
        
        public Vector3 RigidBodyVelocity => physicsController.LinearVelocity;
        
        public bool IsInputMovement() => InputMovement.sqrMagnitude > 0.01f;
        
        #region Sprite Orientation
        public void TryUpdateSpriteDirectionHorizontally() => spriteOrientation.UpdateSpriteDirection(InputMovement);
        
        public Vector3 GetIdleDirection() => new(spriteOrientation.IsFlippedHorizontally() ? -1f : 1f, 0f, 0f);
        
        #endregion
        
        #region Physics Controller
        
        public void SetRigidBodyVelocity(Vector3 velocity) => physicsController.SetLinearVelocity(velocity);

        public bool IsStationary() => Mathf.Approximately(RigidBodyVelocity.normalized.magnitude, 0f);
        
        public void AddForceToRigidBody(Vector3 force, ForceMode mode) => physicsController.AddForce(force, mode);
        
        #endregion
    }
}