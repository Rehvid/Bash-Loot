namespace RehvidGames.Characters.Player
{
    using States;
    using UnityEngine;

    public class Player : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private CharacterSpriteOrientation spriteOrientation;
        
        [field: SerializeField] public CharacterPhysicsController PhysicsController { get; private set;}
        [field: SerializeField] public PlayerStateMachine StateMachine { get; private set; }
        [field: SerializeField] public Animator Animator { get; private set; }
        
        #region Input movement 
        public Vector2 InputMovement { get; set; }
        
        public bool IsInputMovement() => InputMovement.sqrMagnitude > 0.01f;
        #endregion
        
        #region Sprite Orientation
        public void TryUpdateSpriteDirectionHorizontally() => spriteOrientation.UpdateSpriteDirection(InputMovement);
        
        public float GetIdleVelocityDirection() => spriteOrientation.IsFlippedHorizontally() ? -1f : 1f;
        
        #endregion
        
        #region Physics Controller
        
        public Vector2 RigidBodyVelocity () => PhysicsController.LinearVelocity;
        
        public void SetVelocity(Vector2 velocity) => PhysicsController.SetLinearVelocity(velocity);

        public bool IsIdle() => Mathf.Approximately(RigidBodyVelocity().normalized.magnitude, 0f);
        #endregion
    }
}
