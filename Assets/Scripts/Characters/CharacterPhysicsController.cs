namespace RehvidGames.Characters
{
    using UnityEngine;

    public class CharacterPhysicsController : MonoBehaviour
    {
        [SerializeField] private Rigidbody rb;
        
        public Vector3 LinearVelocity => rb.linearVelocity;
        
        public void AddForce(Vector3 force, ForceMode forceMode) => rb.AddForce(force, forceMode);
        public void SetLinearVelocity(Vector3 velocity) => rb.linearVelocity = velocity;
    }
}