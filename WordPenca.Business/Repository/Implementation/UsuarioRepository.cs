using WordPenca.Business.Repository.Interface;
using WordPenca.Business.Domain;
using WordPenca.Business.Persistence;

namespace WordPenca.Business.Repository.Implementation
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {

        public readonly ApplicationDbContext dbContext;

        public UsuarioRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
