using Assets.Scripts.State.Interfaces;
using Assets.Scripts.State.States.GameStates;
using UnityEngine;

namespace Assets.Scripts.State.Contexts
{
    class GameStateContext
    {
        private Ball ball;

        private IGameState currentState;

        private int parCount;

        public GameStateContext(Ball ballIn)
        {
            ball = ballIn;
            currentState = new PlayState();
            parCount = 0;
        }

        //public void Init()
        //{
        //    currentState = new PlayState();
        //    parCount = 0;
        //}

        // Increase par count, disable user game input (not HUD), enter process state
        public void HandleHitBall()
        {
            currentState.Hit(this);
        }

        // Idle state?, run animations maybe. 
        public void HandleProcessBall()
        {
            currentState.Process(this);
        }

        // Next level or continue where you have left of (or out of bounds, return back to initial position)
        public void HandleEndGame()
        {
            currentState.IsTermination(this);
        }

        public void ChangeState(IGameState stateIn)
        {
            Debug.Log($"{currentState.GetType().Name} to {stateIn.GetType().Name}");
            currentState = stateIn;
        }

        public Ball GetBall()
        {
            return ball;
        }

        public IGameState GetCurrentState()
        {
            return currentState;
        }

        public void IncParC()
        {
            ++parCount;
        }
    }
}
