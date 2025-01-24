namespace RehvidGames.Player
{
    using UnityEngine;
    using UnityEngine.InputSystem;
    using Utilities;

    public class PlayerMovementController : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private Rigidbody rb;
        [SerializeField] private SpriteRenderer characterSprite;
        [SerializeField] private Animator animator;
        
        [Header("Properties")] 
        [SerializeField] private float speed = 5f;
        [SerializeField] private float jumpForce = 5f;
        [SerializeField] private float dashForce = 20f;
        [SerializeField] private float fallSpeedMultiplier = 3f;
        [SerializeField] private LayerMask groundLayer;
        
        private Vector2 inputMovement;
        private bool isJumping;
        private bool onGround;
        
        private void Start()
        { 
            InitializeOnGround();
        }

        private void InitializeOnGround()
        {
            if (TryGetComponent(out SphereCollider sphereCollider))
            {
                onGround = Physics.CheckSphere(sphereCollider.center, sphereCollider.radius, groundLayer);
            }
            else
            {
                Debug.LogWarning("No SphereCollider found for ground check. Player may not detect collisions with the ground.");
            }
        }
        
        private void FixedUpdate()
        {
            if (CanApplyMovement()) 
            {
                ApplyMovement();
            }
            
            if (CanPerformJump())
            {
                PerformJump();
            }

            if (CanApplyFallingForce())
            {
                ApplyFallingForce();
            }
            
            animator.SetFloat(AnimatorParameter.YVelocity, rb.linearVelocity.y);
        }

        private bool CanApplyMovement() => onGround && !isJumping;

        private bool CanPerformJump() => isJumping && onGround;

        private bool CanApplyFallingForce() => rb.linearVelocity.y < 0;
        
        private void ApplyMovement()
        {
            rb.linearVelocity = new Vector3(inputMovement.x, 0, inputMovement.y) * speed;
            if (!Mathf.Approximately(inputMovement.x, 0))
            {
                characterSprite.flipX = inputMovement.x < 0;
            }
            
            animator.SetFloat(AnimatorParameter.XVelocity, rb.linearVelocity.magnitude);
        }
        
        private void ApplyFallingForce() => AddForceToRigidBody(Vector3.down * fallSpeedMultiplier, ForceMode.Acceleration);
        
        private void PerformJump()
        {
            AddForceToRigidBody(Vector3.up * jumpForce, ForceMode.Impulse); 
            onGround = false;
            animator.SetTrigger(AnimatorParameter.IsJumping);
        }
         
        public void OnMove(InputAction.CallbackContext context) => inputMovement = context.ReadValue<Vector2>();
        
        public void OnJump(InputAction.CallbackContext context) => isJumping = context.performed;

        public void OnDash(InputAction.CallbackContext context)
        {
            if (!context.performed || !onGround) return;
            
            float linearVelocityMagnitude = rb.linearVelocity.magnitude;
            Vector3 force = rb.linearVelocity;
            if (linearVelocityMagnitude == 0)
            {
                force = new Vector3(characterSprite.flipX ? -1f : 1f, 0f, 0f);
            }
            
            AddForceToRigidBody(force * dashForce, ForceMode.Impulse);
            animator.SetTrigger(AnimatorParameter.Dash);
        }

        private void AddForceToRigidBody(Vector3 force, ForceMode mode) => rb.AddForce(force, mode);
        
        private void OnCollisionEnter(Collision other) => UpdateGroundState(other, true);
        
        private void OnCollisionExit(Collision other) => UpdateGroundState(other, false);
        
        private void UpdateGroundState(Collision collision, bool state)
        {
            if (!IsCollidingWithGround(collision)) return;
            
            onGround = state;
            animator.SetBool(AnimatorParameter.OnGround, state);
        }
        
        private bool IsCollidingWithGround(Collision collision) => ((1 << collision.gameObject.layer) & groundLayer) != 0; 
    }
}
