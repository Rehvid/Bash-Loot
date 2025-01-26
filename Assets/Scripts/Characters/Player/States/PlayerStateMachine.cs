namespace RehvidGames.Characters.Player.States
{
    using Enums;
    using RehvidGames.States;
    using UnityEngine;

    public class PlayerStateMachine: StateMachine<PlayerState>
    {
        [Header("Components")]
        [SerializeField] private Animator animator;
        [SerializeField] private Player player;
        [SerializeField] private PlayerMovementData movementData;
        
        private void Awake()
        {
            states.Add(PlayerState.Block, new PlayerBlockState(animator));
            states.Add(PlayerState.Idle, new PlayerIdleState());
            states.Add(PlayerState.Roll, new PlayerRollState(animator, player, movementData.IdleRollForce));
            states.Add(PlayerState.Attack, new PlayerAttackState(animator));
            states.Add(PlayerState.Dash, new PlayerDashState(animator, player, movementData.DashForce));
            states.Add(PlayerState.Jump, new PlayerJumpState(animator, player, movementData.JumpForce, movementData.FallSpeedMultiplier));
            states.Add(PlayerState.Walk, new PlayerWalkState(animator, player, movementData.Speed));
            
            currentState = states[PlayerState.Idle];
        }

        public void SwitchState(PlayerState newState)
        {
            StateTransition(newState);
        }
    }
}