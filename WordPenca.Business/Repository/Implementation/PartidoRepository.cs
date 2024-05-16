using System.Linq.Expressions;

using WordPenca.Business.Repository.Interface;
using WordPenca.Business.Domain;
using WordPenca.Business.Persistence;

namespace WordPenca.Business.Repository.Implementation
{
    public class PartidoRepository : Repository<Partido>, IPartidoRepository
    {

        public readonly ApplicationDbContext dbContext;

        public PartidoRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
