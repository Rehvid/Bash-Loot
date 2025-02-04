namespace RehvidGames.States
{
    using System;
    using Enums;
    using Interfaces;

    public abstract class BaseState<EState>: IState  where EState : Enum
    {
        public EState StateKey { get; private set; }
        
        protected BaseState(EState key)
        {
            StateKey = key;
        }
        
        public virtual void EnterState() {}
        
        public virtual void ExitState() {}
        
        public virtual void FrameUpdate() {}
        
        public virtual void PhysicsUpdate() {}
        
        public virtual void AnimationTriggerEvent(AnimationTriggerType triggerType) {}
    }
}