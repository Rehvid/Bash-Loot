namespace RehvidGames.Characters
{
    using UnityEngine;

    public class CharacterSpriteOrientation: MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;
        
        public void FlipHorizontally(bool flip) => spriteRenderer.flipX = flip;
        
        public bool IsFlippedHorizontally() => spriteRenderer.flipX;
    }
}