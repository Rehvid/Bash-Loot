namespace RehvidGames.Characters.Player
{
    using UnityEngine;

    [CreateAssetMenu(fileName = "PlayerMovementData", menuName = "Data/Player Movement")]
    public class PlayerMovementData : ScriptableObject
    {
        [Header("Dash & Roll")]
        [field: SerializeField] public float DashForce { get; private set; } = 20f;
        [field: SerializeField] public float IdleRollForce { get; private set; } = 12.5f;
        
        [Header("Movement")]
        [field: SerializeField] public float Speed { get; private set; } = 5f;
        
        [Header("Jump")]
        [field: SerializeField] public float JumpForce { get; private set; } = 5f;
        [field: SerializeField] public float FallSpeedMultiplier { get; private set; } = 3f;
    }
}