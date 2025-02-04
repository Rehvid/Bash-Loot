namespace RehvidGames.Characters.Enemy.States
{
    using Enums;
    using RehvidGames.States;
    using UnityEngine;

    public class EnemyChaseState : BaseState<EnemyState>
    {
        private readonly Enemy enemy;
        
        private GameObject player;
        
        public EnemyChaseState(Enemy enemy) : base(EnemyState.Chasing)
        {
            this.enemy = enemy;
            
            player = GameObject.FindGameObjectWithTag("Player");
        }

        public override void EnterState()
        {
            enemy.Movement.SetChaseSpeed();
            enemy.Movement.Direction = GetPlayerDirection();
        }

        public override void FrameUpdate()
        {
            enemy.Movement.Direction = GetPlayerDirection();
        }
        
        private Vector2 GetPlayerDirection()
        {
            var playerDirection = new Vector2(player.transform.position.x, player.transform.position.y);
            
            return (playerDirection - enemy.GetPosition()).normalized;
        }

        public override void ExitState()
        {
            enemy.Movement.SetMovementSpeed();
        }
    }
}