using Assets.Scripts.State.Contexts;
using Assets.Scripts.State.Interfaces;
using System;
using UnityEngine;

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
            {
                // DELIKSIZ ATMIS ISE ANIMASYON GIR
                if(context.GetBounceCount() == 0)
                {
                    Debug.Log("Well done!");
                }
                context.ChangeState(new NextGameState(context));
                context.HandleNextGame();
            }
            else
            {
                context.ChangeState(new PlayState(context));
            }
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
