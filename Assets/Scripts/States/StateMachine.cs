namespace RehvidGames.States
{
    using System;
    using System.Collections.Generic;
    using Interfaces;
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
            Debug.Log($"stateMachine: {currentState.GetType().Name}");
            if (isInTransitionState) return;
            
            currentState.FrameUpdate();
        }

        private void FixedUpdate()
        {
            Debug.Log($"stateMachine FIXEDUPDATE: {currentState.GetType().Name}");
            if (isInTransitionState) return;
            
            currentState.PhysicsUpdate();
        }

        public bool IsInState(EState stateKey) => currentState.StateKey.Equals(stateKey);
        
        public void AddContextToState(IContext context) => currentState.InputContext(context);
        
        protected void StateTransition(EState stateKey)
        {
            isInTransitionState = true;
            currentState.ExitState();
            
            currentState = states[stateKey];
            currentState.EnterState();
            
            isInTransitionState = false;
        }
    }
}