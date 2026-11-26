using System;
using GuessNumberGame.Interfaces;
using GuessNumberGame.Models;
using GuessNumberGame.Services;
using GuessNumberGame.UI;

namespace GuessNumberGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Угадай число";

            ISettingsManager settingsMgr = new FileSettingsManager();
            IStatisticsManager statsMgr = new FileStatisticsManager();
            IGameEngine engine = new GameEngine();
            ConsoleUI myUI = new ConsoleUI(engine, statsMgr);

            GameSettings mySettings = settingsMgr.ReadSettings();

            bool work = true;

            while (work)
            {
                Console.Clear();
                ShowMenu(mySettings);

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        myUI.PlayGame(mySettings.Level);
                        break;

                    case "2":
                        EditSettings(settingsMgr, ref mySettings);
                        break;

                    case "3":
                        ShowStatistics(statsMgr);
                        break;

                    case "0":
                        work = false;
                        break;

                    default:
                        Console.WriteLine("Нет такого пункта!");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void ShowMenu(GameSettings settings)
        {
            Console.WriteLine("       УГАДАЙ ЧИСЛО");
            Console.WriteLine("Игрок: " + settings.Nickname);
            Console.WriteLine("Уровень: " + settings.Level);
            Console.WriteLine("1 - Играть");
            Console.WriteLine("2 - Настройки");
            Console.WriteLine("3 - Статистика");
            Console.WriteLine("0 - Выйти");
            Console.Write("Что выберешь? ");
        }

        static void EditSettings(ISettingsManager settingsMgr, ref GameSettings settings)
        {
            Console.Clear();
            Console.WriteLine("Настройки ");

            Console.Write("Новое имя: ");
            string newName = Console.ReadLine();
            if (newName != "")
            {
                settings.Nickname = newName;
            }

            Console.Write("Сложность (1, 2 или 3): ");
            string lvlText = Console.ReadLine();
            int newLvl;
            bool isOk = int.TryParse(lvlText, out newLvl);

            if (isOk && newLvl >= 1 && newLvl <= 3)
            {
                settings.Level = newLvl;
            }
            else
            {
                Console.WriteLine("Неверная сложность, оставим старую.");
            }

            settingsMgr.WriteSettings(settings);
            Console.WriteLine("\nСохранено! Нажми клавишу...");
            Console.ReadKey();
        }

        static void ShowStatistics(IStatisticsManager statsMgr)
        {
            Console.Clear();
            Console.WriteLine(" Статистика ");
            PlayerStats st = statsMgr.ReadStats();

            Console.WriteLine("Сыграно игр: " + st.Matches);
            Console.WriteLine("Побед: " + st.Wins);
            Console.WriteLine("Поражений: " + st.Fails);

            if (st.BestScore > 0)
            {
                Console.WriteLine("Рекорд: " + st.BestScore + " попыток");
            }
            else
            {
                Console.WriteLine("Рекорда пока нет.");
            }

            Console.WriteLine("\nНажми клавишу...");
            Console.ReadKey();
        }
    }
}
