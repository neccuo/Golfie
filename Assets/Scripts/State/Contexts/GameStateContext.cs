using Assets.Scripts.State.Interfaces;
using Assets.Scripts.State.States.GameStates;

namespace Assets.Scripts.State.Contexts
{
    class GameStateContext
    {
        private IGameState currentState;

        private int parCount;

        public void Init()
        {
            currentState = new PlayState();
            parCount = 0;
        }

        // Increase par count, disable user game input (not HUD)
        public void HandleHitBall()
        {
            currentState.Hit(this);
        }

        // Idle state?, run animations maybe. 
        public void ProcessBallUntilStop()
        {
            currentState.ProcessUntilStop(this);
        }

        // Next level or continue where you have left of (or out of bounds, return back to initial position)
        public void HandleEndGame()
        {
            currentState.HandleIsTermination(this);
        }

        void ChangeState(IGameState stateIn)
        {
            currentState = stateIn;
        }

        void IncParC()
        {
            ++parCount;
        }
    }
}
