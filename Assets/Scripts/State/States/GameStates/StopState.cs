using Assets.Scripts.State.Contexts;
using Assets.Scripts.State.Interfaces;
using System;

namespace Assets.Scripts.State.States.GameStates
{
    class StopState : IGameState
    {
        void IGameState.HandleIsTermination(GameStateContext contextIn)
        {
            throw new NotImplementedException();
        }

        void IGameState.Hit(GameStateContext contextIn)
        {
            throw new NotImplementedException();
        }

        void IGameState.ProcessUntilStop(GameStateContext contextIn)
        {
            throw new NotImplementedException();
        }
    }
}
