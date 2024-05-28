namespace WordPenca.Business.Domain
{
    public class ResultSet
    {
        public int Count { get; set; }
        public string? Competitions { get; set; }
        public DateTime First { get; set; }
        public DateTime Last { get; set; }
        public int Played { get; set; }
    }
}