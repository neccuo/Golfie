using Assets.Scripts.State.Contexts;

namespace Assets.Scripts.State.Interfaces
{
    interface IGameState
    {
        public void Hit(GameStateContext contextIn);
        public void Process(GameStateContext contextIn);
        public void IsTermination(GameStateContext contextIn);
    }
}
