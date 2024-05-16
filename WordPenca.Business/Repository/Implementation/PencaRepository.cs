
using WordPenca.Business.Models;
using WordPenca.Business.Persistence;
using WordPenca.Business.Repository.Interface;

namespace WordPenca.Business.Repository.Implementation
{
    public class PencaRepository : Repository<Penca>, IPencaRepository
    {
        private readonly ApplicationDbContext _db;

        public PencaRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
