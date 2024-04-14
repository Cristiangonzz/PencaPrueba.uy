namespace WordPenca.Business.Domain
{
    public class Partido
    {

        public Guid id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int golLocal { get; set; } = 0;
        public int golVisitante { get; set; } = 0;
        public List<Equipo> equipos { get; set; }
    }
}
