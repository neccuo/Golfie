using Assets.Scripts.State.Contexts;
using Assets.Scripts.State.Interfaces;
using System;

namespace Assets.Scripts.State.States.GameStates
{
    class ProcessState : IGameState
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
            // If out of bounds, go to play state
            // If in bounds and stopped moving, go to stop state
            // If in bounds and moving, do nothing

            Ball ball = contextIn.GetBall();

            if(!ball.IsBallInBounds())
            {
                ball.ResetBallPosition();
                contextIn.ChangeState(new PlayState());
            }
            else if(!ball.IsBallMoving())
            {
                // bad code
                contextIn.ChangeState(new StopState());
                contextIn.HandleEndGame();
            }
        }
    }
}
