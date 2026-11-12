using System;
using GuessNumberGame.Models;
using GuessNumberGame.Interfaces;

namespace GuessNumberGame.Services
{
    public class GameEngine : IGameEngine
    {
        private int _hiddenNumber;  
        private int _maxRange;       
        private Random _rndGenerator; 

        public int CurrentLimit => _maxRange;

        public GameEngine()
        {
            _rndGenerator = new Random();
        }

        public void StartGame(int Level)
        {
            switch (Level)
            {
                case 1:
                    _maxRange = 10;
                    break;
                case 2:
                    _maxRange = 100;
                    break;
                case 3:
                    _maxRange = 1000;
                    break;
                default:
                    _maxRange = 10; 
                    break;
            }

            _hiddenNumber = _rndGenerator.Next(1, _maxRange + 1);
        }

        public GuessResult CheckNumber(int inputNum)
        {
            if (inputNum == _hiddenNumber)
            {
                return GuessResult.Guessed;
            }
            else if (inputNum > _hiddenNumber)
            {
                return GuessResult.Over;
            }
            else
            {
                return GuessResult.Under;
            }
        }
    }
}