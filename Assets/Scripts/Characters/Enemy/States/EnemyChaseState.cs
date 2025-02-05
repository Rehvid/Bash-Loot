namespace RehvidGames.Characters.Enemy.States
{
    using Enums;
    using Player;
    using RehvidGames.States;
    using UnityEngine;

    public class EnemyChaseState : BaseState<EnemyState>
    {
        private readonly Enemy enemy;
        
        private Player player;
        
        public EnemyChaseState(Enemy enemy) : base(EnemyState.Chasing)
        {
            this.enemy = enemy;
            
            var gameObjectPlayer =  GameObject.FindGameObjectWithTag("Player");
            
            if (!gameObjectPlayer.TryGetComponent(out player))
            {
                Debug.LogError("Player not found in scene!");
            }
        }

        public override void EnterState()
        {
            enemy.Movement.SetChaseSpeed();
            SetMovementDirection();
        }

        public override void FrameUpdate()
        {
            SetMovementDirection();
        }
        
        private Vector2 GetPlayerDirection()
        {
            return (player.GetPosition() - enemy.GetPosition()).normalized;
        }
        
        private void SetMovementDirection() => enemy.Movement.Direction = GetPlayerDirection();

        public override void ExitState()
        {
            enemy.Movement.SetMovementSpeed();
        }
    }
}