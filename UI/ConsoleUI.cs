using System;
using GuessNumberGame.Interfaces;
using GuessNumberGame.Models;

namespace GuessNumberGame.UI
{
    public class ConsoleUI
    {
        private IGameEngine _gameEngine;
        private IStatisticsManager _stats;

        public ConsoleUI(IGameEngine engine, IStatisticsManager statistics)
        {
            _gameEngine = engine;
            _stats = statistics;
        }

        public void PlayGame(int diffLevel)
        {
            Console.Clear();
            Console.WriteLine(" Игра началась!\n");

            _gameEngine.StartGame(diffLevel);

            int attempts = 0;
            bool isWin = false;

            while (isWin == false)
            {
                Console.Write("Твоя догадка: ");
                string userText = Console.ReadLine();

                int guess;
                bool isNumber = int.TryParse(userText, out guess);

                if (isNumber == false)
                {
                    Console.WriteLine("Это не число! Попробуй еще раз.");
                    continue;
                }

                attempts = attempts + 1; 

                GuessResult res = _gameEngine.CheckNumber(guess);

                if (res == GuessResult.Guessed)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\n Ты угадал! Понадобилось попыток: {attempts}");
                    Console.ResetColor();

                    isWin = true;
                    _stats.AddGameResult(true, attempts);
                }
                else if (res == GuessResult.Over)
                {
                    Console.WriteLine("Мое число МЕНЬШЕ.");
                }
                else
                {
                    Console.WriteLine("Мое число БОЛЬШЕ.");
                }
            }

            Console.WriteLine("\nНажми любую клавишу...");
            Console.ReadKey();
        }
    }
}