namespace GuessNumberGame.Models
{
    public class PlayerStats
    {
        public int Matches { get; set; }
        public int Wins { get; set; }
        public int Fails { get; set; } 
        public int BestScore { get; set; } 

        public PlayerStats()
        {
            Matches = 0;
            Wins = 0;
            Fails = 0;
            BestScore = 0;
        }
    }
}