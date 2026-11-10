using System;
using GuessNumberGame.Models;

namespace GuessNumberGame.Interfaces
{
    public interface IGameEngine
    {
        void StartGame( int Level);
        GuessResult CheckNumber(int inputNum);
    }
}