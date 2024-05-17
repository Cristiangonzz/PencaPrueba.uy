using Microsoft.EntityFrameworkCore;
using WordPenca.Business.Domain;
using WordPenca.Business.Models;

namespace WordPenca.Business.Persistence
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
      
        public DbSet<Equipo> Equipos { get; set; }

        public DbSet<Partido> Partidos { get; set; }

        public DbSet<Campionato> Campeonatos { get; set; }
        public DbSet<Tabla> Tablas { get; set; }
        public DbSet<Clasificacion> Clasificacions { get; set; }
        public DbSet<Penca> penca { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Apuesta> Apuestas { get; set; }
    }
}
