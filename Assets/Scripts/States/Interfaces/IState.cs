namespace RehvidGames.States.Interfaces
{
    using Enums;

    public interface IState
    {
        public void EnterState();
        public void ExitState();
        public void FrameUpdate();
        public void PhysicsUpdate();
        public void AnimationTriggerEvent(AnimationTriggerType triggerType) {}
    }
}