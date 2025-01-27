namespace RehvidGames.States
{
    using System;
    using System.Collections.Generic;
    using UnityEngine;

    public class StateMachine<EState> : MonoBehaviour where EState : Enum
    {
        protected Dictionary<EState, BaseState<EState>> states = new();
        protected BaseState<EState> currentState;
        
        private bool isInTransitionState;

        private void Start()
        {
            currentState.EnterState();
        }

        private void Update()
        {
            if (isInTransitionState) return;
            
            currentState.FrameUpdate();
        }

        private void FixedUpdate()
        {
            if (isInTransitionState) return;
            
            currentState.PhysicsUpdate();
        }

        public bool IsInState(EState stateKey) => currentState.StateKey.Equals(stateKey);
        
        protected void StateTransition(EState stateKey)
        {
            isInTransitionState = true;
            currentState.ExitState();
            
            currentState = states[stateKey];
            currentState.EnterState();
            
            isInTransitionState = false;
        }
        
        protected void ResetToStateIfInState(EState current, EState target)
        {
            if (IsInState(current))
            {
                StateTransition(target);
            }
        }
    }
}