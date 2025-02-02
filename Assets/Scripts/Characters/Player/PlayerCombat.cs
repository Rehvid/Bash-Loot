namespace RehvidGames.Characters.Player
{
    using Animator;
    using Enums;
    using UnityEngine;
    using UnityEngine.InputSystem;

    public class PlayerCombat : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private Player player;
         
        public void OnAttack(InputAction.CallbackContext context) => HandleStateChange(context, PlayerState.Attack);
        
        public void OnAttackEnd() => player.StateMachine.ResetToIdleIfInState(PlayerState.Attack);
        
        public void OnRoll(InputAction.CallbackContext context) => HandleStateChange(context, PlayerState.Roll);
        
        public void OnRollEnd() => player.StateMachine.ResetToIdleIfInState(PlayerState.Roll);

        public void OnBlock(InputAction.CallbackContext context) => HandleBlockState(context);

        public void OnBlockIdle()
        {
            if (player.StateMachine.IsInState(PlayerState.Block))
            {
                player.Animator.SetBool(CombatAnimatorParameters.IsBlockingIdle, true); 
            }
        }

        private void HandleStateChange(InputAction.CallbackContext context, PlayerState targetState)
        {
            if (IsContextPerformedAndIsNotInJumpState(context))
            {
                player.StateMachine.SwitchState(targetState);
            }
        }

        private void HandleBlockState(InputAction.CallbackContext context)
        {
            if (player.StateMachine.IsInState(PlayerState.Jump)) return; 
            
            if (context.performed)
            {
                player.StateMachine.SwitchState(PlayerState.Block);
            } else if (context.canceled)
            {
                player.StateMachine.SwitchState(PlayerState.Idle); 
            }
        }
        
        private bool IsContextPerformedAndIsNotInJumpState(InputAction.CallbackContext context) =>
            context.performed && !player.StateMachine.IsInState(PlayerState.Jump);
    }
}