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
        
        [Header("Debug")]
        [SerializeField] private bool useDebug;
        
        private void OnCollisionEnter(Collision other) => UpdateGroundState(other, true);
        private void OnCollisionExit(Collision other) => UpdateGroundState(other, false);
        
        private void UpdateGroundState(Collision collision, bool state)
        {
            if (!IsCollidingWithGround(collision)) return;
            groundCheck?.Invoke(state);
        }
        
        private bool IsCollidingWithGround(Collision collision) 
            => ((1 << collision.gameObject.layer) & groundLayer) != 0; 
    }
}