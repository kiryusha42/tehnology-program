using System.IO;
using System.Text.Json;
using GuessNumberGame.Models;
using GuessNumberGame.Interfaces;

namespace GuessNumberGame.Services
{
    public class FileSettingsManager : ISettingsManager
    {
        private readonly string _mySavePath = "my_settings.json";

        public GameSettings ReadSettings()
        {
            if (!File.Exists(_mySavePath))
            {
                return new GameSettings();
            }

            string textFromFile;
            using (StreamReader reader = new StreamReader(_mySavePath))
            {
                textFromFile = reader.ReadToEnd();
            }

            return JsonSerializer.Deserialize<GameSettings>(textFromFile) ?? new GameSettings();
        }

        public void WriteSettings(GameSettings config)
        {
            string textForFile = JsonSerializer.Serialize(config);
            File.WriteAllText(_mySavePath, textForFile);
        }
    }
}