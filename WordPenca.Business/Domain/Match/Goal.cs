namespace WordPenca.Business.Domain
{
    public class Goal
    {
        public int Minute { get; set; }
        public int? InjuryTime { get; set; }
        public string? Type { get; set; }
        public Team? Team { get; set; }
        public Player? Scorer { get; set; }
        public Player? Assist { get; set; }
        public ScoreTime? Score { get; set; }
    }
}