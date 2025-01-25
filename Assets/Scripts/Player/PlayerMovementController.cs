namespace RehvidGames.Player
{
    using UnityEngine;
    using UnityEngine.InputSystem;
    using Utilities;
    using Animator;

    public class PlayerMovementController : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private GroundChecker groundChecker;
        [SerializeField] private Player player;
        [SerializeField] private Animator animator;
        
        [Header("Properties")] 
        [SerializeField] private float speed = 5f;
        [SerializeField] private float jumpForce = 5f;
        [SerializeField] private float dashForce = 20f;
        [SerializeField] private float fallSpeedMultiplier = 3f;
        
        private Vector2 inputMovement;
        private bool isJumping;
        private bool onGround;
        
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
            
            animator.SetFloat(MovementAnimatorParameters.YVelocity, player.RigidBodyVelocity.y);
        }

        private bool CanApplyMovement() => onGround && !isJumping;

        private bool CanPerformJump() => isJumping && onGround;

        private bool CanApplyFallingForce() => player.RigidBodyVelocity.y < 0;
        
        private void ApplyMovement()
        {
            player.SetRigidBodyVelocity(new Vector3(inputMovement.x, 0, inputMovement.y) * speed);
            if (!Mathf.Approximately(inputMovement.x, 0))
            {
                player.FlipSpriteRenderHorizontally(inputMovement.x < 0);
            }
            
            animator.SetFloat(MovementAnimatorParameters.XVelocity, player.RigidBodyVelocity.magnitude);
        }
        
        private void ApplyFallingForce() => player.AddForceToRigidBody(Vector3.down * fallSpeedMultiplier, ForceMode.Acceleration);
        
        private void PerformJump()
        {
            player.AddForceToRigidBody(Vector3.up * jumpForce, ForceMode.Impulse); 
            animator.SetTrigger(MovementAnimatorParameters.Jump);
        }
         
        public void OnGroundChange(bool state)
        {
            if (onGround == state) return;
            
            onGround = state;
            animator.SetBool(MovementAnimatorParameters.OnGround, state);
        }
        
        public void OnMove(InputAction.CallbackContext context) => inputMovement = context.ReadValue<Vector2>();
        
        public void OnJump(InputAction.CallbackContext context) => isJumping = context.performed;

        public void OnDash(InputAction.CallbackContext context)
        {
            if (!context.performed || !onGround) return;
            
            Vector3 force = player.IsStationary() ? player.GetIdleDirection() : player.RigidBodyVelocity;
            
            player.AddForceToRigidBody(force * dashForce, ForceMode.Impulse);
            animator.SetTrigger(MovementAnimatorParameters.Dash);
        }
    }
}
