namespace RehvidGames.Characters.Enemy.States
{
    using Enums;
    using RehvidGames.States;

    public class EnemyStateMachine: StateMachine<EnemyState>
    {
        private void Awake()
        {
            states.Add(EnemyState.Patrolling, new EnemyPatrolState());
            states.Add(EnemyState.Searching, new EnemySearchState());
            states.Add(EnemyState.Chasing, new EnemyChaseState());
            states.Add(EnemyState.Attacking, new EnemyAttackState());

            currentState = states[EnemyState.Patrolling];
        }

        public void SwitchState(EnemyState newState)
        {
            StateTransition(newState);
        }
    }
}