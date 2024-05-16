namespace WordPenca.Business.Domain
{
    public class Equipo 
    {
        public Guid id { get; set; }
        public string name { get; set; } = null!;
        
        public bool activo { get; set; } = true;
    }
}
