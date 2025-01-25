namespace RehvidGames.Player
{
    using Animator;
    using UnityEngine;
    using UnityEngine.InputSystem;

    public class PlayerCombat : MonoBehaviour
    {
        [SerializeField] private float idleRollForce = 12.5f;
        
        private Animator animator;
        private Rigidbody rb;
        private SpriteRenderer spriteRenderer;
        private bool isBlockHolding;

        private void Start()
        {
            TryGetComponent(out animator);
            TryGetComponent(out rb);
            TryGetComponent(out spriteRenderer);
        }

        public void OnAttack(InputAction.CallbackContext context)
        {
            if (!context.performed) return;
            
            animator.SetTrigger(CombatAnimatorParameters.Attack);
        }
        
        public void OnRoll(InputAction.CallbackContext context)
        {
            if (!context.performed) return;
            
            if (rb.linearVelocity.normalized.magnitude == 0)
            {  
                rb.AddForce(new Vector3(spriteRenderer.flipX ? -1f : 1f, 0f, 0f) * idleRollForce, ForceMode.Impulse);   
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