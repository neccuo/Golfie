using Assets.Scripts.State.Contexts;

namespace Assets.Scripts.State.Interfaces
{
    interface IGameState
    {
        public void Hit();
        public void Process();
        public void IsTermination();
    }
}
