


using WordPenca.Business.Domain;
using WordPenca.Business.Persistence;
using WordPenca.Business.Repository.Interface;

namespace WordPenca.Business.Repository.Implementation
{
    public class CampeonatoRepository : Repository<Campionato>, ICampeonatoRepository
    {
        public readonly ApplicationDbContext dbContext;

        public CampeonatoRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
