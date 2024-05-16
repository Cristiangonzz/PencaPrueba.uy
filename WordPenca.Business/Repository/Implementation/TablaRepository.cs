using WordPenca.Business.Domain;
using WordPenca.Business.Persistence;

using WordPenca.Business.Repository.Interface;



namespace WordPenca.Business.Repository.Implementation
{
    public class TablaRepository : Repository<Tabla>, ITablaRepository
    {
        private readonly ApplicationDbContext _db;

        public TablaRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
