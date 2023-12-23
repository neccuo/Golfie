using Assets.Scripts.State.Interfaces;
using Assets.Scripts.State.States.GameStates;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.State.Contexts
{
    class GameStateContext
    {
        public UnityEvent<int> updateParEvent;

        private GameMediator gameMediator;

        private Ball ball;

        private IGameState currentState;

        private int parCount;

        public GameStateContext(Ball ballIn)
        {
            updateParEvent = new UnityEvent<int>();
            gameMediator = GameObject.FindGameObjectWithTag("GameMediator")
                                       .GetComponent<GameMediator>();
            updateParEvent.AddListener(gameMediator.UpdateParCounterTxt);
            ball = ballIn;
            Init();
        }

        public void Init()
        {
            currentState = new PlayState(this);
            ball.InitBall();
            UpdateParC(0);
        }

        //public void Init()
        //{
        //    currentState = new PlayState(this);
        //    UpdateParC(0);
        //}

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

        public void HandleNextGame()
        {
            Init();
            gameMediator.OpenNextMap();
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
        }

        public void IncParC()
        {
            UpdateParC(parCount+1);
        }
    }
}
