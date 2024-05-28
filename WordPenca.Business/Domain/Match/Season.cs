namespace WordPenca.Business.Domain
{
    public class Season
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int CurrentMatchday { get; set; }
        public object? Winner { get; set; }
        public List<string>? Stages { get; set; }
    }
}