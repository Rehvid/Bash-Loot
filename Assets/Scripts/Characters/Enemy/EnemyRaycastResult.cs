namespace RehvidGames.Characters.Enemy
{
    using UnityEngine;

    public struct EnemyRaycastResult
    {
        public LayerMask DetectedLayer { get; private set; }
        public RaycastHit2D Hit { get; private set; }
        
        public Vector2 HitPoint => Hit.point;
        
        public bool IsPlayerDetected => Hit.collider != null && Hit.collider.CompareTag("Player");
        
        public bool IsLayerDetected => DetectedLayer != 0;
        
        public EnemyRaycastResult(RaycastHit2D hit)
        {
            Hit = hit;
            DetectedLayer = hit.collider != null ? (LayerMask) hit.collider.gameObject.layer : 0;
        }
    }
}