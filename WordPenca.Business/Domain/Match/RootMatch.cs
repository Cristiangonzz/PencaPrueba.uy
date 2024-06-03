namespace WordPenca.Business.Domain
{
    public class RootMatch
    {
        public Filter Filters { get; set; } = null!;
        public ResultSet ResultSet { get; set; } = null!;
        public List<Match> Matches { get; set; } = new List<Match>();
    }
}