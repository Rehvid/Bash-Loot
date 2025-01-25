namespace RehvidGames.Player
{
    using Animator;
    using UnityEngine;
    using UnityEngine.InputSystem;

    public class PlayerCombat : MonoBehaviour
    {
        private Animator animator;
        private bool isBlockHolding;

        private void Start()
        {
            TryGetComponent(out animator);
        }

        public void OnAttack(InputAction.CallbackContext context)
        {
            if (!context.performed) return;
            
            animator.SetTrigger(CombatAnimatorParameters.Attack);
        }
        
        public void OnRoll(InputAction.CallbackContext context)
        {
            if (!context.performed) return;
            
            animator.SetTrigger(CombatAnimatorParameters.Roll);
        }

        public void OnBlock(InputAction.CallbackContext context)
        {
            isBlockHolding = context.performed;
            if (context.performed)
            {
                animator.SetTrigger(CombatAnimatorParameters.Block);
            } else if (context.canceled)
            {
                animator.SetBool(CombatAnimatorParameters.IsBlockingIdle, false);
            }
        }

        public void OnBlockIdle()
        {
            if (!isBlockHolding) return;
            
            animator.SetBool(CombatAnimatorParameters.IsBlockingIdle, true); 
        }
    }
}