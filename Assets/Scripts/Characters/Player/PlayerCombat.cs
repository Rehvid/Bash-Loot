namespace RehvidGames.Characters.Player
{
    using Animator;
    using Enums;
    using UnityEngine;
    using UnityEngine.InputSystem;

    public class PlayerCombat : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private Animator animator;
        [SerializeField] private Player player;
        
        public void OnAttack(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                player.StateMachine.SwitchState(PlayerState.Attack);
            }
        }

        public void OnAttackEnd() => player.StateMachine.SwitchState(PlayerState.Idle);
        
        public void OnRoll(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                player.StateMachine.SwitchState(PlayerState.Roll);
            } 
        }
        
        public void OnRollEnd() => player.StateMachine.SwitchState(PlayerState.Idle);

        public void OnBlock(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                player.StateMachine.SwitchState(PlayerState.Block);
            } else if (context.canceled)
            {
                player.StateMachine.SwitchState(PlayerState.Idle); 
            }
        }

        public void OnBlockIdle()
        {
            if (player.StateMachine.IsInState(PlayerState.Block))
            {
                animator.SetBool(CombatAnimatorParameters.IsBlockingIdle, true); 
            }
        }
    }
}