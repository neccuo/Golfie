using Assets.Scripts.State.Contexts;

namespace Assets.Scripts.State.Interfaces
{
    interface IGameState
    {
        public void Hit(GameStateContext contextIn);
        public void ProcessUntilStop(GameStateContext contextIn);
        public void HandleIsTermination(GameStateContext contextIn);
    }
}
