namespace RehvidGames.Characters.Player
{
    using UnityEngine;

    public class PlayerPhysicsController : MonoBehaviour
    {
        [field: SerializeField] public Rigidbody2D Rigidbody2D { get; private set; }
        
        public void ChangeGravityScale(float gravityScale) => Rigidbody2D.gravityScale = gravityScale;
        
        public void SetLinearVelocity(Vector2 velocity) => Rigidbody2D.linearVelocity = velocity;
        
        public void ApplyForwardVelocity(float force)
        {
            Rigidbody2D.position += new Vector2(force * Time.fixedDeltaTime, Rigidbody2D.linearVelocity.y);
        }
        
        public void SetIdleVelocity(float idleVelocity, float force)
        {
            var newVelocity = new Vector2(idleVelocity * force, Rigidbody2D.linearVelocity.y);
            SetLinearVelocity(newVelocity);
        }
        
        public bool IsIdle() => Mathf.Approximately(Rigidbody2D.linearVelocity.normalized.magnitude, 0f);
    }
}