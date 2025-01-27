namespace RehvidGames.Characters.Player
{
    using UnityEngine;

    [CreateAssetMenu(fileName = "PlayerMovementData", menuName = "Data/Player Movement")]
    public class PlayerMovementData : ScriptableObject
    {
        [Header("Dash & Roll")]
        [field: SerializeField] public float DashForce { get; private set; } = 2f;
        
        [field: SerializeField] public float DashIdleForce { get; private set; } = 1f;
        
        [field: SerializeField] public float RollIdleForce { get; private set; } = 3f;
        
        [field: SerializeField] public float RollForce { get; private set; } = 6f;
        
        [Header("Movement")]
        [field: SerializeField] public float Speed { get; private set; } = 5f;
        
        [Header("Jump")]
        [field: SerializeField] public float JumpForce { get; private set; } = 5f;
        [field: SerializeField] public float FallSpeedMultiplier { get; private set; } = 3f;
    }
}