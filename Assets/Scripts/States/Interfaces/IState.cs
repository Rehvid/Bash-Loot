﻿namespace RehvidGames.States.Interfaces
{
    public interface IState
    {
        public void EnterState();
        public void ExitState();
        public void FrameUpdate();
        public void PhysicsUpdate();
    }
}