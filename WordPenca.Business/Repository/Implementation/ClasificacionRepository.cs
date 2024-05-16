

using WordPenca.Business.Repository.Interface;
using WordPenca.Business.Domain;
using WordPenca.Business.Persistence;

namespace WordPenca.Business.Repository.Implementation
{
    public class ClasificacionRepository : Repository<Clasificacion>, IClasificacionRepository
    {

        public readonly ApplicationDbContext dbContext;

        public ClasificacionRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
