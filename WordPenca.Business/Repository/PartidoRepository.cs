using WordPenca.Business.Persistence;
using WordPenca.Business.Service;
using WordPenca.Business.Domain;

namespace WordPenca.Business.Repository
{
    public class PartidoRepository : IPartidoRepository
    {

        public readonly ApplicationDbContext dbContext;

        public PartidoRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public Task<Partido> CreateAsync(Partido entity)
        {
            throw new NotImplementedException();
        }

        public Task<Partido> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<List<Partido>> GetById(Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}
