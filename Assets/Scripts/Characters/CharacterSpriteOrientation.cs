namespace RehvidGames.Characters
{
    using UnityEngine;

    public enum FacingDirection
    {
        Left = -1,
        Right = 1
    }
    
    public class CharacterSpriteOrientation: MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;

        public FacingDirection CurrentDirection { get; private set; } = FacingDirection.Right;
        private bool isFacingRightDirection = true;
        
        public void UpdateSpriteDirection(Vector2 inputMovement) 
        {
            if (IsMovingHorizontally(inputMovement) && ShouldFlipHorizontally(inputMovement))
            {
                FlipHorizontally();
            }
        }

        private bool ShouldFlipHorizontally(Vector2 inputMovement)
        {
            return inputMovement.x > 0 && !isFacingRightDirection || inputMovement.x < 0 && isFacingRightDirection;
        }
        
        private bool IsMovingHorizontally(Vector2 inputMovement)
        {
            return !Mathf.Approximately(inputMovement.x, 0);
        }

        private void FlipHorizontally()
        {
            ChangeDirection();
            transform.Rotate(0, 180, 0);
        }

        private void ChangeDirection()
        {
            CurrentDirection = CurrentDirection == FacingDirection.Left ? FacingDirection.Right : FacingDirection.Left;
            isFacingRightDirection = !isFacingRightDirection;
        }
    }
}