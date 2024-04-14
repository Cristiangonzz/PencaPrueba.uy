namespace WordPenca.Business.Domain
{
    public class Clasificacion
    {
        public Guid Id { get; set; }
        public Equipo Equipo { get; set; }
        public int Point { get; set; }
        public int Posicion { get; set; }
        public int PartidosJugados { get; set; }
        public int GolesAF { get; set; }
        public int GolesEC { get; set; }
        public int Victorias { get; set; }
        public int Derrotas { get; set; }
        public int Empatados { get; set; }


    }
}
