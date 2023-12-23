using Assets.Scripts.State.Contexts;
using Assets.Scripts.State.Interfaces;
using System;

namespace Assets.Scripts.State.States.GameStates
{
    class PlayState : IGameState
    {
        GameStateContext context;

        public PlayState(GameStateContext contextIn)
        {
            context = contextIn;
            // Enable Input

            // TODO: BE CAREFUL ABOUT THIS
            GameInputSystem.Instance.EnableInput();
        }

        void IGameState.IsTermination()
        {
            throw new NotImplementedException();
        }

        void IGameState.Hit()
        {

            // DISABLE OUTPUT
            GameInputSystem.Instance.DisableInput();

            context.IncParC();


            context.ChangeState(new ProcessState(context));
        }

        void IGameState.Process()
        {
            throw new NotImplementedException();
        }
    }
}
