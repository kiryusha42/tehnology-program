using GuessNumberGame.Models;

namespace GuessNumberGame.Interfaces
{
    public interface IStatisticsManager
    {
        PlayerStats ReadStats();
        void AddGameResult(bool isWin, int moves);
    }
}