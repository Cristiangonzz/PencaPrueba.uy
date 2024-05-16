namespace WordPenca.Business.Domain
{
    public class Apuesta
    {
        public Guid Id { get; set; }

        public Usuario Usuario { get; set; }
        public Partido Partido { get; set; }
        public int GolesLocal { get; set; }
        public int GolesVisitante { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
