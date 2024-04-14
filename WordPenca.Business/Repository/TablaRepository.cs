using WordPenca.Business.Persistence;
using WordPenca.Business.Service;
using WordPenca.Business.Domain;

namespace WordPenca.Business.Repository
{
    public class TablaRepository : ITablaRepository
    {

        public readonly ApplicationDbContext dbContext;

        public TablaRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<Tabla> CreateAsync(Tabla entity)
        {
            throw new NotImplementedException();
        }

        public Task<Tabla> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<List<Tabla>> GetById(Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}
