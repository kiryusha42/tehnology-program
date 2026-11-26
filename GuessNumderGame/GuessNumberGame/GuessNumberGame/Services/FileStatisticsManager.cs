using System.IO;
using System.Text.Json;
using GuessNumberGame.Models;
using GuessNumberGame.Interfaces;

namespace GuessNumberGame.Services
{
    public class FileStatisticsManager : IStatisticsManager
    {
        private readonly string _mySavePath = "my_stats.json";
        private PlayerStats _myStats;

        public FileStatisticsManager()
        {
            _myStats = ReadStats();
        }

        public PlayerStats ReadStats()
        {
            if (!File.Exists(_mySavePath))
            {
                return new PlayerStats();
            }

            string textFromFile;
            using (StreamReader reader = new StreamReader(_mySavePath))
            {
                textFromFile = reader.ReadToEnd();
            }

            return JsonSerializer.Deserialize<PlayerStats>(textFromFile) ?? new PlayerStats();
        }

        public void AddGameResult(bool isWin, int moves)
        {
            _myStats.Matches++;

            if (isWin)
            {
                _myStats.Wins++;
                if (_myStats.BestScore == 0 || moves < _myStats.BestScore)
                {
                    _myStats.BestScore = moves;
                }
            }
            else
            {
                _myStats.Fails++;
            }

            string textForFile = JsonSerializer.Serialize(_myStats);
            File.WriteAllText(_mySavePath, textForFile);
        }
    }
}