namespace RehvidGames.Characters.Enemy
{
    using Animator;
    using UnityEngine;

    public class EnemyMovement : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private CharacterPhysicsController physicsController;
        [SerializeField] private CharacterSpriteOrientation spriteOrientation;
        [SerializeField] private Animator animator;
        
        [Header("Settings")]
        [SerializeField] private float movementSpeed = 3f;
        [SerializeField] private float chaseSpeed = 5f;
        
        public Vector2 Direction { get; set; } = Vector2.zero;
        
        private bool isStopped;
        private float currentSpeed;
        
        private void Start()
        {
            currentSpeed = movementSpeed;
        }

        private void FixedUpdate()
        {
            if (!isStopped)
            {
                ApplyMovement();
            }
        }

        private void ApplyMovement()
        {
            spriteOrientation.UpdateSpriteDirection(Direction);
            MovePosition();
            SetAnimatorSpeed();
        }

        private void MovePosition()
        {
            var newPosition = physicsController.Position + Direction.normalized * (currentSpeed * Time.fixedDeltaTime);
            physicsController.MovePosition(newPosition);
        }

        public bool IsTargetReached(Vector2 targetPosition, float maxDistanceToTargetForStop)
        {
            float distance = Vector2.Distance(physicsController.Position, targetPosition);
            
            return distance <= maxDistanceToTargetForStop; 
        }

        public void SetChaseSpeed()
        {
            currentSpeed = chaseSpeed;
            SetAnimatorSpeed();
        }

        public void SetMovementSpeed()
        {
            currentSpeed = movementSpeed;
            SetAnimatorSpeed();
        } 
        
        public void StopMovement()
        {
             physicsController.SetLinearVelocity(Vector2.zero);
             isStopped = true;
             SetAnimatorSpeed();
        }
        
        public void ResumeMovement() => isStopped = false;

        private void SetAnimatorSpeed()
        {
            animator.SetFloat(MovementAnimatorParameters.XVelocity, isStopped ? 0 : currentSpeed);
        }
    }
}