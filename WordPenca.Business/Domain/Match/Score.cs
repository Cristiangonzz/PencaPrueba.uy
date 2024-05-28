namespace WordPenca.Business.Domain
{
    public class Score
    {
        public object? Winner { get; set; }
        public string? Duration { get; set; }
        public ScoreTime? FullTime { get; set; }
        public ScoreTime? HalfTime { get; set; }
    }
}