namespace RehvidGames.Player
{
    using Character;
    using UnityEngine;

    public class Player : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private CharacterSpriteOrientation spriteOrientation;
        [SerializeField] private CharacterPhysicsController physicsController;

        public Vector3 RigidBodyVelocity => physicsController.LinearVelocity;
        
        public void FlipSpriteRenderHorizontally(bool flip) => spriteOrientation.FlipHorizontally(flip);
        
        public Vector3 GetIdleDirection() => new(spriteOrientation.IsFlippedHorizontally() ? -1f : 1f, 0f, 0f);
        
        public void SetRigidBodyVelocity(Vector3 velocity) => physicsController.SetLinearVelocity(velocity);

        public bool IsStationary() => Mathf.Approximately(RigidBodyVelocity.normalized.magnitude, 0f);
        
        public void AddForceToRigidBody(Vector3 force, ForceMode mode) => physicsController.AddForce(force, mode);
    }
}