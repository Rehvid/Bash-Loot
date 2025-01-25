namespace RehvidGames.Player
{
    using UnityEngine;
    using UnityEngine.InputSystem;
    using Utilities;

    public class PlayerCombat : MonoBehaviour
    {
        private Animator animator;

        private void Start()
        {
            TryGetComponent(out animator);
        }

        public void OnAttack(InputAction.CallbackContext context)
        {
            if (!context.performed) return;
            
            animator.SetTrigger(CombatAnimatorParameters.Attack);
        }
    }
}