using Assets.Scripts.State.Contexts;
using Assets.Scripts.State.Interfaces;
using System;

namespace Assets.Scripts.State.States.GameStates
{
    class NextGameState : IGameState
    {
        void IGameState.IsTermination(GameStateContext contextIn)
        {
            throw new NotImplementedException();
        }

        void IGameState.Hit(GameStateContext contextIn)
        {
            throw new NotImplementedException();
        }

        void IGameState.Process(GameStateContext contextIn)
        {
            throw new NotImplementedException();
        }
    }
}
