using WordPenca.Business.Repository.Interface;
using WordPenca.Business.Persistence;

namespace WordPenca.Business.Repository.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        //public IApplicationUserRepository ApplicationUser { get; private set; }
        public IPencaRepository Penca { get; private set; }
        public ICampeonatoRepository Campeonato { get; private set; }
        public IPartidoRepository Partido { get; private set; }
        public IEquipoRepository Equipo { get; private set; }
        public ITablaRepository Tabla { get; private set; }
        public IClasificacionRepository Clasificacion { get; private set; }
        public IUsuarioRepository Usuario { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            // ApplicationUser = new ApplicationUserRepository(_db);
            Penca = new PencaRepository(_db);
            Campeonato = new CampeonatoRepository(_db);
            Partido = new PartidoRepository(_db);
            Equipo = new EquipoRepository(_db);
            Tabla = new TablaRepository(_db);
            Clasificacion = new ClasificacionRepository(_db);
            Penca = new PencaRepository(_db);
            Usuario = new UsuarioRepository(_db);

        }

        public void Save()
        {
            _db.SaveChangesAsync();
        }
    }
}
