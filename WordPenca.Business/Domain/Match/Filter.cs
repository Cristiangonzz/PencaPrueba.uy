namespace WordPenca.Business.Domain
{
    public class Filter
    {
        public DateOnly DateFrom { get; set; }
        public DateOnly DateTo { get; set; }
        public string Permission { get; set; }
    }
}