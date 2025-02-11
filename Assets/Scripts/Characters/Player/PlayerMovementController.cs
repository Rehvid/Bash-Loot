namespace RehvidGames.Characters.Player
{
    using Animator;
    using Enums;
    using Utilities;
    using UnityEngine;
    using UnityEngine.InputSystem;

    public class PlayerMovementController : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private GroundChecker groundChecker;
        [SerializeField] private Player player;
        
        private bool isJumping;
        private bool onGround;
        
        private void FixedUpdate()
        {
            if (player.IsDead()) return; 
            
            if (CanApplyMovement()) 
            {
                player.StateMachine.SwitchState(PlayerState.Walk);
            }
            
            if (CanPerformJump())
            {
                player.StateMachine.SwitchState(PlayerState.Jump);
            }
            
            player.Animator.SetFloat(MovementAnimatorParameters.YVelocity, player.GetVelocity().y);
        }

        private bool CanApplyMovement()
        {
            return (onGround && !isJumping) 
                   && player.StateMachine.IsInState(PlayerState.Idle) 
                   && player.IsInputMovement();
        }
        
        
        private bool CanPerformJump() => isJumping && onGround;
        
        public void OnGroundChange(bool state)
        {
            if (onGround == state) return;
            
            onGround = state;
            player.Animator.SetBool(MovementAnimatorParameters.OnGround, state);
            
            if (player.StateMachine.IsInState(PlayerState.Jump) && state)
            {
                player.StateMachine.SwitchState(PlayerState.Idle);
            }
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            if (player.IsDead()) return;
            
            player.InputMovement = context.ReadValue<Vector2>();
        }

        public void OnJump(InputAction.CallbackContext context)
        {
            if (player.IsDead()) return;
            
            isJumping = context.performed;
        }

        public void OnDash(InputAction.CallbackContext context)
        {
            if (CanDash(context))
            {
                player.StateMachine.SwitchState(PlayerState.Dash);
            }
        }

        private bool CanDash(InputAction.CallbackContext context)
        {
            return context.performed
                   && onGround
                   && !player.StateMachine.IsInState(PlayerState.Jump)
                   && !player.IsDead();
        }
        
    }
}
