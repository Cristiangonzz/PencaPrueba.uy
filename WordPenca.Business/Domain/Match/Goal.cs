namespace WordPenca.Business.Domain
{
    public class Goal
    {
        public int? minute { get; set; }
        public int? injuryTime { get; set; }
        public string? type { get; set; }
        public Team? team { get; set; }
        public Player? scorer { get; set; }
        public Player? assist { get; set; }
        public ScoreTime? score { get; set; }
    }
}