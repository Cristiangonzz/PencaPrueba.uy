using WordPenca.Business.Persistence;
using WordPenca.Business.Service;
using WordPenca.Business.Domain;

namespace WordPenca.Business.Repository
{
    public class CampionatoRepository : ICampionatoRepository
    {
        public readonly ApplicationDbContext dbContext;

        public CampionatoRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Campionato> CreateAsync(Campionato entity)
        {
            try
            {
                dbContext.Set<Campionato>().Add(entity);
                await dbContext.SaveChangesAsync();
                return entity;
            }
            catch
            {
                throw;
            }
        }

        public Task<Campionato> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<List<Campionato>> GetById(Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}
