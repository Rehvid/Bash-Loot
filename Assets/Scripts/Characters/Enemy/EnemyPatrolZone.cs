namespace RehvidGames.Characters.Enemy
{
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;

    public class EnemyPatrolZone : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private CircleCollider2D circleCollider2D;
        
        [Header("Settings")]
        [SerializeField, Min(1)] private int pointsToGenerate = 5;
        [SerializeField, Min(0.1f)] private float minDistanceBetweenPoints = 2f;
        [SerializeField, Tooltip("Maximum number of attempts to generate a valid patrol point. If this limit is exceeded, the point generation will fail.")] 
        private int maxRetriesBeforeFailure = 10; 
        
        [Header("Debug")] 
        [SerializeField] private bool useDebug;
        [SerializeField] private Color patrolPointColor;
        
        private readonly List<Vector2> patrolPoints = new();
        private readonly List<Vector2> visitedPatrolPoints = new();
        
        private void Awake() => GenerateRandomPoints();
        
        private void GenerateRandomPoints()
        {
            patrolPoints.Clear();
            float radius = circleCollider2D.radius * transform.lossyScale.x;
            Vector2 colliderCenter = GetColliderCenter();
            
            for (var i = 0; i < pointsToGenerate; i++)
            {
                if (TryGenerateRandomPoint(radius, colliderCenter, out Vector2 newPoint))
                {
                    patrolPoints.Add(newPoint);
                }
            }
        }
        
        private Vector2 GetColliderCenter()
        {
            var currentPosition = new Vector2(transform.position.x, transform.position.y);
            var circleOffset = new Vector2(circleCollider2D.offset.x, circleCollider2D.offset.y);
            return currentPosition + circleOffset;
        }
        
        private bool TryGenerateRandomPoint(float radius, Vector2 center, out Vector2 point)
        {
            for (var attempt = 0; attempt < maxRetriesBeforeFailure; attempt++)
            {
                point = center + GetRandomPointOnSphere(radius);
                if (point == Vector2.zero) continue;
                
                if (IsFarEnoughFromOtherPoints(point))
                {
                    return true;
                }
            }
            
            point = Vector2.zero;
            return false;
        }
        
        private Vector2 GetRandomPointOnSphere(float radius)
        {
            Vector2 point = Random.insideUnitCircle;
            point.y = 0;
            
            return point * radius;
        }
        
        private bool IsFarEnoughFromOtherPoints(Vector2 point) => 
            patrolPoints.All(existingPoint => Vector2.Distance(point, existingPoint) >= minDistanceBetweenPoints);
        
        public Vector2 GetRandomPatrolPoint()
        {
            if (patrolPoints.Count == 0) return transform.position;

            Vector2 randomPatrolPoint = patrolPoints
                .Where(patrolPoint => !visitedPatrolPoints.Contains(patrolPoint))
                .OrderBy(_ => Random.value) 
                .FirstOrDefault();
            
            if (randomPatrolPoint != default)
            {
                visitedPatrolPoints.Add(randomPatrolPoint);
                return randomPatrolPoint;
            }
            
            visitedPatrolPoints.Clear();
            return patrolPoints[Random.Range(0, patrolPoints.Count)];
        }
        
        private void OnDrawGizmos()
        {
            if (!useDebug || !circleCollider2D) return;
            
            Gizmos.color = patrolPointColor;
            foreach (var point in patrolPoints)
            {
                Gizmos.DrawSphere(point, 0.2f);
            }
        }
    }
}