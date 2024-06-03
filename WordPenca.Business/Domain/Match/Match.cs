namespace WordPenca.Business.Domain
{
    public class Match
    {
        public Area? Area { get; set; }
        public Competition? Competition { get; set; }
        public Season? Season { get; set; }
        public int Id { get; set; }
        public DateOnly UtcDate { get; set; }
        public string? Status { get; set; }
        public string? Minute { get; set; }  // Nueva propiedad
        public int? InjuryTime { get; set; }  // Nueva propiedad
        public int? Attendance { get; set; }  // Nueva propiedad
        public string? Venue { get; set; }  // Nueva propiedad
        public int Matchday { get; set; }
        public string? Stage { get; set; }
        public string? Group { get; set; }
        public DateOnly LastUpdated { get; set; }
        public Team? HomeTeam { get; set; }
        public Team? AwayTeam { get; set; }
        public Score? Score { get; set; }
        public List<Goal>? Goals { get; set; }  // Nueva propiedad
        public List<Penalty>? Penalties { get; set; }  // Nueva propiedad
        public List<Booking>? Bookings { get; set; }  // Nueva propiedad
        public List<Substitution>? Substitutions { get; set; }  // Nueva propiedad
        public Odds? Odds { get; set; }
        public List<object>? Referees { get; set; }
    }
}