namespace WordPenca.Business.Domain
{
    public class Penalty
    {
        public Player? player { get; set; }
        public Team? team { get; set; }
        public bool? scored { get; set; }
    }
}