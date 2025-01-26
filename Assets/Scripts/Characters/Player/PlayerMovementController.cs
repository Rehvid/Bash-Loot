namespace RehvidGames.Characters.Player
{
    using Animator;
    using Contexts;
    using Enums;
    using Utilities;
    using UnityEngine;
    using UnityEngine.InputSystem;

    public class PlayerMovementController : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private GroundChecker groundChecker;
        [SerializeField] private Player player;
        [SerializeField] private Animator animator;
        
        private bool isJumping;
        private bool onGround;

        private readonly PlayerWalkContext walkContext = new ();
        
        private void FixedUpdate()
        {
            if (CanApplyMovement()) 
            {
                ApplyMovement();
            }
            
            if (CanPerformJump())
            {
                player.StateMachine.SwitchState(PlayerState.Jump);
            }
            
            animator.SetFloat(MovementAnimatorParameters.YVelocity, player.RigidBodyVelocity.y);
        }

        private bool CanApplyMovement() => onGround && !isJumping;

        private bool CanPerformJump() => isJumping && onGround;
        
        private void ApplyMovement()
        {
            if (!player.StateMachine.IsInState(PlayerState.Walk))
            {
                player.StateMachine.SwitchState(PlayerState.Walk);
            }
            player.StateMachine.AddContextToState(walkContext);
        }
        
        public void OnGroundChange(bool state)
        {
            if (onGround == state) return;
            
            onGround = state;
            animator.SetBool(MovementAnimatorParameters.OnGround, state);
            
            if (player.StateMachine.IsInState(PlayerState.Jump) && state)
            {
                player.StateMachine.SwitchState(PlayerState.Idle);
            }
        }

        public void OnMove(InputAction.CallbackContext context) => walkContext.InputMovement = context.ReadValue<Vector2>();
        
        public void OnJump(InputAction.CallbackContext context) => isJumping = context.performed;

        public void OnDash(InputAction.CallbackContext context)
        {
            if (!context.performed || !onGround) return;
            
            player.StateMachine.SwitchState(PlayerState.Dash);
        }

        public void OnDashEnd() => player.StateMachine.SwitchState(PlayerState.Idle);
    }
}
