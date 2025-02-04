namespace RehvidGames.Characters.Player.States
{
    using Enums;
    using RehvidGames.States;
    using UnityEngine;

    public class PlayerStateMachine: StateMachine<PlayerState>
    {
        [Header("Components")]
        [SerializeField] private Player player;
        [SerializeField] private PlayerMovementData movementData;
        
        private void Awake()
        {
            states.Add(PlayerState.Idle, new PlayerIdleState());
            states.Add(PlayerState.Walk, new PlayerWalkState(player, movementData.Speed));
            states.Add(PlayerState.Roll, new PlayerRollState(player, movementData.RollIdleForce, movementData.RollForce));
            states.Add(PlayerState.Attack, new PlayerAttackState(player));
            states.Add(PlayerState.Dash, new PlayerDashState(player, movementData.DashForce, movementData.DashIdleForce));
            states.Add(PlayerState.Jump, new PlayerJumpState(player, movementData.JumpForce, movementData.FallSpeedMultiplier));
            states.Add(PlayerState.Block, new PlayerBlockState(player));
            
            CurrentState = states[PlayerState.Idle];
        }

        public void SwitchState(PlayerState newState)
        {
            StateTransition(newState);
        }

        public void ResetToIdleIfInState(PlayerState currentState)
        {
            ResetToStateIfInState(currentState, PlayerState.Idle);
        }
    }
}