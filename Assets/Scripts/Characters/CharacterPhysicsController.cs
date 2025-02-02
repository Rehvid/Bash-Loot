namespace RehvidGames.Characters
{
    using UnityEngine;

    public class CharacterPhysicsController : MonoBehaviour
    {
        [SerializeField] public Rigidbody2D rb; 
        
        public float GravityScale => rb.gravityScale;
        
        public Vector2 LinearVelocity => rb.linearVelocity;
        
        public void ChangeGravityScale(float gravityScale) =>  rb.gravityScale = gravityScale; 
        
        public void AddForce(Vector2 force, ForceMode2D forceMode) => rb.AddForce(force, forceMode);
        
        public void SetLinearVelocity(Vector2 velocity) => rb.linearVelocity = velocity;
    }
}