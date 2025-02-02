namespace RehvidGames.Utilities
{
    using UnityEngine;
    using UnityEngine.Events;

    public class GroundChecker: MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private LayerMask groundLayer;
        
        [Header("Events")]
        [SerializeField] private UnityEvent<bool> groundCheck;
        
        
        private void OnCollisionEnter2D(Collision2D other) => UpdateGroundState(other, true);
        private void OnCollisionExit2D(Collision2D other) => UpdateGroundState(other, false);
        
        private void UpdateGroundState(Collision2D collision, bool state)
        {
            if (!IsCollidingWithGround(collision)) return;
            groundCheck?.Invoke(state);
        }
        
        private bool IsCollidingWithGround(Collision2D collision) 
            => ((1 << collision.gameObject.layer) & groundLayer) != 0; 
    }
}