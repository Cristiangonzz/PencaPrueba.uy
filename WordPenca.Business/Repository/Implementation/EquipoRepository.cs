using WordPenca.Business.Repository.Interface;
using WordPenca.Business.Domain;
using WordPenca.Business.Persistence;

namespace WordPenca.Business.Repository.Implementation
{
    public class EquipoRepository : Repository<Equipo>, IEquipoRepository
    {

        public readonly ApplicationDbContext dbContext;

        public EquipoRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
