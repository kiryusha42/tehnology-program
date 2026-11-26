using GuessNumberGame.Models;

namespace GuessNumberGame.Interfaces
{
    public interface ISettingsManager
    {
        GameSettings ReadSettings();
        void WriteSettings(GameSettings config);
    }
}