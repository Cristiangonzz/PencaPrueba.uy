namespace WordPenca.Business.Domain
{
    public class Campionato 
    {

        public Guid Id { get; set; }
        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        
        public List<Equipo> Equipos { get; set; }
        public DateTime CreationDate { get; set;}

    }
}
