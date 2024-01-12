using Assets.Scripts.State.Interfaces;
using Assets.Scripts.State.States.GameStates;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.State.Contexts
{
    class GameStateContext
    {
        private readonly UnityEvent<int> updateParEvent;
        private readonly UnityEvent<int> updateBounceEvent;

        private GameMediator gameMediator;

        private Ball ball;

        private IGameState currentState;

        private int parCount;
        private int bounceCount;


        public GameStateContext(Ball ballIn)
        {
            // init events
            updateParEvent = new UnityEvent<int>();
            updateBounceEvent = new UnityEvent<int>();

            gameMediator = GameObject.FindGameObjectWithTag("GameMediator")
                                       .GetComponent<GameMediator>();

            // add listeners
            updateParEvent.AddListener(gameMediator.UpdateParCounterTxt);
            updateBounceEvent.AddListener(gameMediator.UpdateBounceCounterTxt);

            ball = ballIn;
            InitGame();
        }

        // IT MUST BE CALLED AT THE BEGINNING
        public void InitGame()
        {
            currentState = new PlayState(this);
            ball.InitBall();
            ResetBounceCount();
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

        public void HandleNextGame()
        {
            InitGame();
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

        public void UpdateBounceC(int bounceCountIn)
        {
            // Event system
            updateBounceEvent.Invoke(bounceCountIn);
        }

        public void IncParC()
        {
            UpdateParC(parCount+1);
        }

        // BOUNCE REALM
        public int GetBounceCount()
        {
            return bounceCount;
        }

        public void IncBounceCount()
        {
            SetBounceCount(bounceCount + 1);
        }

        public void ResetBounceCount()
        {
            SetBounceCount(0);
        }

        private void SetBounceCount(int countIn)
        {
            bounceCount = countIn;
            UpdateBounceC(bounceCount);
            Debug.Log($"Bounce Count SET: {bounceCount}");
        }
    }
}
