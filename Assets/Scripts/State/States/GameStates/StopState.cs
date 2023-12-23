using Assets.Scripts.State.Contexts;
using Assets.Scripts.State.Interfaces;
using System;

namespace Assets.Scripts.State.States.GameStates
{
    class StopState : IGameState
    {
        GameStateContext context;

        public StopState(GameStateContext contextIn)
        {
            context = contextIn;
        }

        void IGameState.IsTermination()
        {
            Ball ball = context.GetBall();

            if (ball.IsBallInGoalArea())
                context.ChangeState(new NextGameState(context));
            else
                context.ChangeState(new PlayState(context));
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
