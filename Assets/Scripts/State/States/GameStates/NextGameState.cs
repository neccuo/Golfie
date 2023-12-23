using Assets.Scripts.State.Contexts;
using Assets.Scripts.State.Interfaces;
using System;

namespace Assets.Scripts.State.States.GameStates
{
    class NextGameState : IGameState
    {
        GameStateContext context;

        public NextGameState(GameStateContext contextIn)
        {
            context = contextIn;
        }

        void IGameState.IsTermination()
        {
            throw new NotImplementedException();
        }

        void IGameState.Hit()
        {
            throw new NotImplementedException();
        }

        void IGameState.Process()
        {
            throw new NotImplementedException();
        }
    }
}
