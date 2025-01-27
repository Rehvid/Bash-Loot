namespace RehvidGames.Characters
{
    using UnityEngine;

    public class CharacterSpriteOrientation: MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;

        public void UpdateSpriteDirection(Vector2 inputMovement)
        {
            if (IsMovingHorizontally(inputMovement))
            {
                FlipHorizontally(inputMovement.x < 0);
            }
        }
        
        private bool IsMovingHorizontally(Vector2 inputMovement)
        {
            return !Mathf.Approximately(inputMovement.x, 0);
        }
        
        private void FlipHorizontally(bool flip) => spriteRenderer.flipX = flip;
        
        public bool IsFlippedHorizontally() => spriteRenderer.flipX;
    }
}