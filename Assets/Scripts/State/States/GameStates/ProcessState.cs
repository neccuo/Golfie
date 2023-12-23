using Assets.Scripts.State.Contexts;
using Assets.Scripts.State.Interfaces;
using System;

namespace Assets.Scripts.State.States.GameStates
{
    class ProcessState : IGameState
    {
        GameStateContext context;

        public ProcessState(GameStateContext contextIn)
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
            // If out of bounds, go to play state
            // If in bounds and stopped moving, go to stop state
            // If in bounds and moving, do nothing

            Ball ball = context.GetBall();

            if(!ball.IsBallInBounds())
            {
                ball.ResetBallPosition();
                context.ChangeState(new PlayState(context));
            }
            else if(!ball.IsBallMoving())
            {
                context.ChangeState(new StopState(context));
                context.HandleEndGame();
            }
        }
    }
}
