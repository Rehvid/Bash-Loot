namespace RehvidGames.Characters.Player
{
    using System;
    using Characters;
    using Contexts;
    using RehvidGames.States.Interfaces;
    using States;
    using UnityEngine;

    public class Player : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private CharacterSpriteOrientation spriteOrientation;
        [SerializeField] private CharacterPhysicsController physicsController;
        [field: SerializeField] public PlayerStateMachine StateMachine { get; private set; }
        
        public PlayerWalkContext WalkContext { get; } = new ();
        
        public Vector3 RigidBodyVelocity => physicsController.LinearVelocity;
        
        
        #region Sprite Orientation
        public void TryFlipSpriteRenderHorizontally() => spriteOrientation.UpdateSpriteDirection(WalkContext.InputMovement);
        
        public Vector3 GetIdleDirection() => new(spriteOrientation.IsFlippedHorizontally() ? -1f : 1f, 0f, 0f);
        
        #endregion
        
        #region Physics Controller
        
        public void SetRigidBodyVelocity(Vector3 velocity) => physicsController.SetLinearVelocity(velocity);

        public bool IsStationary() => Mathf.Approximately(RigidBodyVelocity.normalized.magnitude, 0f);
        
        public void AddForceToRigidBody(Vector3 force, ForceMode mode) => physicsController.AddForce(force, mode);
        
        #endregion
    }
}