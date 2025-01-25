namespace RehvidGames.Characters.Player
{
    using Animator;
    using UnityEngine;
    using UnityEngine.InputSystem;

    public class PlayerCombat : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private Animator animator;
        [SerializeField] private Player player;
        
        [Header("Properties")]
        [SerializeField] private float idleRollForce = 12.5f;
        
        private bool isBlockHolding;
        
        public void OnAttack(InputAction.CallbackContext context)
        {
            if (!context.performed) return;
            
            animator.SetTrigger(CombatAnimatorParameters.Attack);
        }
        
        public void OnRoll(InputAction.CallbackContext context)
        {
            if (!context.performed) return;
            
            if (player.IsStationary())
            {  
                player.AddForceToRigidBody(player.GetIdleDirection() * idleRollForce, ForceMode.Impulse);
            }
            
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