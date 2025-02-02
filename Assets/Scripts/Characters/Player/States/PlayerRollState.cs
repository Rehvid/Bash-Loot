﻿namespace RehvidGames.Characters.Player.States
{
    using Animator;
    using Enums;
    using RehvidGames.States;
    using UnityEngine;

    public class PlayerRollState: BaseState<PlayerState>
    {
        private readonly Player player;
        private readonly float idleRollForce;
        private readonly float rollForce;
        
        public PlayerRollState(Player player, float idleRollForce, float rollForce) : base(PlayerState.Roll)
        {
            this.player = player;
            this.idleRollForce = idleRollForce;
            this.rollForce = rollForce;
        }

        
        public override void EnterState()
        {
            player.Animator.SetFloat(MovementAnimatorParameters.XVelocity, 0);
            
            if (player.IsStationary())
            {  
                player.SetVelocity(new Vector2(player.GetIdleDirection()* idleRollForce , player.RigidBodyVelocity().y));
            }
            else
            {
                player.Rigidbody().position += new Vector2(rollForce * Time.fixedDeltaTime, 0);
            } 
            
            player.Animator.SetTrigger(CombatAnimatorParameters.Roll);
        }
    }
}