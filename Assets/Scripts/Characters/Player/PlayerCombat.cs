namespace RehvidGames.Characters.Player
{
    using Enums;
    using UnityEngine;
    using UnityEngine.InputSystem;

    public class PlayerCombat : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private Player player;
         
        public void OnAttack(InputAction.CallbackContext context) => HandleStateChange(context, PlayerState.Attack);
        
        public void OnRoll(InputAction.CallbackContext context) => HandleStateChange(context, PlayerState.Roll);
        
        public void OnBlock(InputAction.CallbackContext context) => HandleBlockState(context);
        
        private void HandleStateChange(InputAction.CallbackContext context, PlayerState targetState)
        {
            if (player.IsDead()) return;
            
            if (IsContextPerformedAndIsNotInJumpState(context))
            {
                player.StateMachine.SwitchState(targetState);
            }
        }

        private void HandleBlockState(InputAction.CallbackContext context)
        {
            if (player.IsDead() || player.StateMachine.IsInState(PlayerState.Jump)) return; 
            
            if (context.performed)
            {
                player.StateMachine.SwitchState(PlayerState.Block);
            } else if (context.canceled)
            {
                player.StateMachine.SwitchState(PlayerState.Idle); 
            }
        }
        
        private bool IsContextPerformedAndIsNotInJumpState(InputAction.CallbackContext context)
        {
            return context.performed && !player.StateMachine.IsInState(PlayerState.Jump);
        }
    }
}