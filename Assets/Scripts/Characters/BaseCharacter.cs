namespace RehvidGames.Characters
{
    using Enums;
    using UnityEngine;

    public abstract class BaseCharacter: MonoBehaviour
    {
        [Header("Character components")]
        [field: SerializeField] public Animator Animator { get; protected set; }
        
        public abstract void SetAnimationTriggerType(AnimationTriggerType triggerType);
        
        public Vector2 GetPosition() => new (transform.position.x, transform.position.y);
    }
}