namespace RehvidGames.Characters.Enemy
{
    using Enums;
    using Player;
    using UnityEngine;

    public class EnemySight : MonoBehaviour
    {
        [Header("Components")] 
        [SerializeField] private Enemy enemy;
        [SerializeField] private LayerMask layerMasks;
        
        [Header("Settings")]
        [SerializeField] private float detectionDistance = 5f;
        
        [Header("Debug")]
        [SerializeField] private bool useDebug;
        [SerializeField] private Color playerDetectedColor;
        [SerializeField] private Color layerDetectedColor;
        [SerializeField] private Color lineOfSightColor;
        
        public Vector2 LastPlayerPosition { get;  set; }
        public EnemyRaycastResult DetectionResult { get; private set; }
        
        private Player player;
        
        private void Start()
        {
            var gameObjectPlayer =  GameObject.FindGameObjectWithTag("Player");
            
            if (!gameObjectPlayer.TryGetComponent(out player))
            {
                Debug.LogError("Player not found in scene!");
            }
        }

        private void FixedUpdate()
        {
            DetectionResult = RaycastToPlayer();
            
            if (DetectionResult.IsPlayerDetected)
            {
                TryToSwitchChaseState();
                return;
            }

            if (!IsInState(EnemyState.Chasing)) return;

            if (player && !player.IsDead())
            {
                SwitchToSearchState();
            }
        }

        private void TryToSwitchChaseState()
        {
            if (IsInState(EnemyState.Searching) || IsInState(EnemyState.Patrolling))
            {
                SwitchState(EnemyState.Chasing);
            }
        }

        private void SwitchToSearchState()
        {
            LastPlayerPosition = GetPlayerPosition();
            SwitchState(EnemyState.Searching);
        }
        
        private Vector2 GetDirectionToPlayer() => (GetPlayerPosition() - enemy.GetPosition()).normalized;

        private Vector2 GetPlayerPosition()
        {
            return !player ? Vector2.zero : player.GetPosition();
        }

        private bool IsInState(EnemyState state)
        {
            return enemy.StateMachine.IsInState(state);
        }
        
        private void SwitchState(EnemyState state) => enemy.StateMachine.SwitchState(state);
        
        private EnemyRaycastResult RaycastToPlayer()
        {
            RaycastHit2D hit = Physics2D.Raycast(
                enemy.GetPosition(), 
                GetDirectionToPlayer(), 
                detectionDistance, 
                layerMasks
            );

            return new EnemyRaycastResult(hit);
        }
        
        
        private void OnDrawGizmos()
        {
            if (!useDebug || player == null) return;
            
            EnemyRaycastResult result = RaycastToPlayer();

            if (result.IsPlayerDetected)
            {
                Gizmos.color = playerDetectedColor;
                Gizmos.DrawLine(enemy.GetPosition(), result.HitPoint);
            }
            else if (result.IsLayerDetected)
            {
                Gizmos.color = layerDetectedColor;
                Gizmos.DrawLine(enemy.GetPosition(), result.HitPoint);
            }
            else
            {
                Gizmos.color = lineOfSightColor;
                Gizmos.DrawLine(enemy.GetPosition(), enemy.GetPosition() + GetDirectionToPlayer() * detectionDistance);
            }
        }
    }
}