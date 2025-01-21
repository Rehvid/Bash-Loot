namespace RehvidGames.Player
{
    using UnityEngine;
    using UnityEngine.InputSystem;

    public class PlayerController : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private Rigidbody rb;
        [SerializeField] private SpriteRenderer spriteRenderer;

        [Header("Properties")] 
        [SerializeField] private float speed = 10f;
        
        private Vector2 _movement;
        
        private void FixedUpdate()
        {
            UpdateMovement();
        }

        private void UpdateMovement()
        {
            rb.linearVelocity = new Vector3(_movement.x, 0, _movement.y) * speed;
            if (!Mathf.Approximately(_movement.x, 0))
            {
                spriteRenderer.flipX = _movement.x < 0;
            }
        }
        
        public void OnMove(InputAction.CallbackContext context) => _movement = context.ReadValue<Vector2>();
    }
}
