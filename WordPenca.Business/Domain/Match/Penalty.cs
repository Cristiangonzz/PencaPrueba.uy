namespace WordPenca.Business.Domain
{
    public class Penalty
    {
        public Player? Player { get; set; }
        public Team? Team { get; set; }
        public bool Scored { get; set; }
    }
}