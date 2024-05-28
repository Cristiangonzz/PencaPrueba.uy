namespace WordPenca.Business.Domain
{
    public class RootMatch
    {
        public Filter? Filters { get; set; }
        public ResultSet? ResultSet { get; set; }
        public List<Match>? Matches { get; set; }
    }
}