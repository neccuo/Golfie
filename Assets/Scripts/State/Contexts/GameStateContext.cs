using Assets.Scripts.State.Interfaces;
using Assets.Scripts.State.States.GameStates;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.State.Contexts
{
    class GameStateContext
    {
        public UnityEvent<int> updateParEvent;

        private GameUIMediator gameUIMediator;

        private Ball ball;

        private IGameState currentState;

        private int parCount;

        public GameStateContext(Ball ballIn)
        {
            updateParEvent = new UnityEvent<int>();
            gameUIMediator = GameObject.FindGameObjectWithTag("GameUIMediator")
                                       .GetComponent<GameUIMediator>();
            updateParEvent.AddListener(gameUIMediator.UpdateParCounterTxt);
            ball = ballIn;
            Init();
        }

        public void Init()
        {
            currentState = new PlayState(this);
            UpdateParC(0);
        }

        // Increase par count, disable user game input (not HUD), enter process state
        public void HandleHitBall()
        {
            currentState.Hit();
        }

        // Idle state?, run animations maybe. 
        public void HandleProcessBall()
        {
            currentState.Process();
        }

        // Next level or continue where you have left of (or out of bounds, return back to initial position)
        public void HandleEndGame()
        {
            currentState.IsTermination();
        }

        public void ChangeState(IGameState stateIn)
        {
            Debug.Log($"{currentState.GetType().Name} to {stateIn.GetType().Name}");
            currentState = stateIn;
        }

        //private void PostChangeState()

        public Ball GetBall()
        {
            return ball;
        }

        public IGameState GetCurrentState()
        {
            return currentState;
        }

        public void UpdateParC(int parCountIn)
        {
            // Event system
            parCount = parCountIn;
            updateParEvent.Invoke(parCount);
            //gameUIMediator.UpdateParCounterTxt(parCount);
        }

        public void IncParC()
        {
            UpdateParC(parCount+1);
        }
    }
}
