namespace WordPenca.Business.Domain
{
    public class ResultSet
    {
        public int Count { get; set; }
        public string? Competitions { get; set; }
        public DateOnly First { get; set; }
        public DateOnly Last { get; set; }
        public int Played { get; set; }
    }
}