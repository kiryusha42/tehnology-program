namespace GuessNumberGame.Models
{
    public class GameSettings
    {
        public string Nickname { get; set; } 
        public int Level { get; set; }

        public GameSettings() 
        {
            Nickname = "игрок";
                Level = 1;
        }
    }
}   