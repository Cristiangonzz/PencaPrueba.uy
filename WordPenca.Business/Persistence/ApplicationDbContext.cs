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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Chat>()
                .HasOne(g => g.Historial)
                .WithOne(h => h.chat)
                .HasForeignKey<ChatHistorial>(h => h.Id); // Asumiendo que hay una propiedad grupoId en ChatHistorial


            modelBuilder.Entity<Penca>().HasNoKey();
         
        }
        public DbSet<Equipo> Equipos { get; set; }

        public DbSet<Partido> Partidos { get; set; }

        public DbSet<Campionato> Campeonatos { get; set; }
        public DbSet<Tabla> Tablas { get; set; }
        public DbSet<Clasificacion> Clasificacions { get; set; }
        public DbSet<Penca> penca { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Apuesta> Apuestas { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<ChatHistorial> ChatHistorial { get; set; }
        public DbSet<ChatMensaje> ChatMensajes { get; set; }

    }
}
