using Assets.Scripts.State.Contexts;
using Assets.Scripts.State.Interfaces;
using System;

namespace Assets.Scripts.State.States.GameStates
{
    class StopState : IGameState
    {
        void IGameState.IsTermination(GameStateContext contextIn)
        {
            Ball ball = contextIn.GetBall();

            if (ball.IsBallInHole())
                contextIn.ChangeState(new NextGameState());
            else
                contextIn.ChangeState(new PlayState());
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
