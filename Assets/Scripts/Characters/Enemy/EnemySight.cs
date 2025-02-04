namespace RehvidGames.Characters.Enemy
{
    using Enums;
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
        
        public Vector3 LastPlayerPosition { get;  set; }
        
        public EnemyRaycastResult detectionResult;
        private GameObject player;
        
        private void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player");
            if (player == null)
            {
                Debug.LogError("Player not found in scene!");
            }
        }

        private void FixedUpdate()
        {
            detectionResult = RaycastToPlayer();

            if (detectionResult.IsPlayerDetected)
            {
                if (enemy.StateMachine.IsInState(EnemyState.Searching) ||
                    enemy.StateMachine.IsInState(EnemyState.Patrolling))
                {
                    enemy.StateMachine.SwitchState(EnemyState.Chasing);
                }
                return;
            }

            if (enemy.StateMachine.IsInState(EnemyState.Chasing))
            {
                LastPlayerPosition = player.transform.position;
                enemy.StateMachine.SwitchState(EnemyState.Searching);
            }
        }
        
        private Vector3 GetDirectionToPlayer() => (player.transform.position - transform.position).normalized;
        
        private EnemyRaycastResult RaycastToPlayer()
        {
            RaycastHit2D hit = Physics2D.Raycast(
                transform.position, 
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
                Gizmos.DrawLine(transform.position, result.HitPoint);
            }
            else if (result.IsLayerDetected)
            {
                Gizmos.color = layerDetectedColor;
                Gizmos.DrawLine(transform.position, result.HitPoint);
            }
            else
            {
                Gizmos.color = lineOfSightColor;
                Gizmos.DrawLine(transform.position, transform.position + GetDirectionToPlayer() * detectionDistance);
            }
        }
    }
}