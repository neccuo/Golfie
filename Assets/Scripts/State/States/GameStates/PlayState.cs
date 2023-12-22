using Assets.Scripts.State.Contexts;
using Assets.Scripts.State.Interfaces;
using System;
using UnityEngine;

namespace Assets.Scripts.State.States.GameStates
{
    class PlayState : IGameState
    {
        void IGameState.HandleIsTermination(GameStateContext contextIn)
        {
            throw new NotImplementedException();
        }

        void IGameState.Hit(GameStateContext contextIn)
        {
            Debug.Log("Ball was hit");
            //throw new NotImplementedException();
        }

        void IGameState.ProcessUntilStop(GameStateContext contextIn)
        {
            throw new NotImplementedException();
        }
    }
}
