namespace RehvidGames.States
{
    using System;
    using System.Collections.Generic;
    using Enums;
    using UnityEngine;

    public class StateMachine<EState> : MonoBehaviour where EState : Enum
    {
        protected Dictionary<EState, BaseState<EState>> states = new();
        public BaseState<EState> CurrentState { get; protected set; }
        
        private bool isInTransitionState;

        private void Start()
        {
            CurrentState.EnterState();
        }

        private void Update()
        {
            if (isInTransitionState) return;
            
            CurrentState.FrameUpdate();
        }

        private void FixedUpdate()
        {
            if (typeof(EState) == typeof(PlayerState))
            {
                 Debug.LogWarning($"CurrentState: {CurrentState.StateKey} ");
            }
           
            if (isInTransitionState) return;
            
            CurrentState.PhysicsUpdate();
        }

        public bool IsInState(EState stateKey) => CurrentState.StateKey.Equals(stateKey);

        public void OnAnimationTrigger(AnimationTriggerType triggerType)
        {
            CurrentState.AnimationTriggerEvent(triggerType);
        }
        
        protected void StateTransition(EState stateKey)
        {
            isInTransitionState = true;
            CurrentState.ExitState();
            
            CurrentState = states[stateKey];
            CurrentState.EnterState();
            
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