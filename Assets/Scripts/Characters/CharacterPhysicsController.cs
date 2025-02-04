namespace RehvidGames.Characters
{
    using UnityEngine;

    public class CharacterPhysicsController : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rb;
        
        public Vector2 Position => rb.position;
        
        public float GravityScale => rb.gravityScale; 
        
        public Vector2 LinearVelocity => rb.linearVelocity;
        
        public void ChangeGravityScale(float gravityScale) => rb.gravityScale = gravityScale;
        
        public void SetLinearVelocity(Vector2 velocity) => rb.linearVelocity = velocity;
        
        public void ApplyForwardMovement(float force)
        {
            rb.position += new Vector2(force * Time.fixedDeltaTime, rb.linearVelocity.y);
        }

        public void ApplyIdleForce(float idleVelocity, float force)
        {
            var newVelocity = new Vector2(idleVelocity * force, rb.linearVelocity.y);
            SetLinearVelocity(newVelocity);
        }

        public void MovePosition(Vector2 position)
        {
            rb.MovePosition(position);
        }
    }
}