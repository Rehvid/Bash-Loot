namespace RehvidGames.Characters
{
    using UnityEngine;

    public class CharacterPhysicsController : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rb; 
        
        public Vector2 LinearVelocity => rb.linearVelocity;
        
        public void AddForce(Vector2 force, ForceMode2D forceMode) => rb.AddForce(force, forceMode);
        
        public void SetLinearVelocity(Vector2 velocity) => rb.linearVelocity = velocity;
    }
}