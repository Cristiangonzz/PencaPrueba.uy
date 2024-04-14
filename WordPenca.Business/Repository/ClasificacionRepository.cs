

using WordPenca.Business.Persistence;
using WordPenca.Business.Service;
using WordPenca.Business.Domain;

namespace WordPenca.Business.Repository
{
    public class ClasificacionRepository : IClasificacionRepository
    {

        public readonly ApplicationDbContext dbContext;

        public ClasificacionRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public Task<Clasificacion> CreateAsync(Clasificacion entity)
        {
            throw new NotImplementedException();
        }

        public Task<Clasificacion> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<List<Clasificacion>> GetById(Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}
