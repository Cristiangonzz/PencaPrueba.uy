using WordPenca.Business.Persistence;
using WordPenca.Business.Domain;
using WordPenca.Business.Repository.Interface;

namespace WordPenca.Business.Repository.Implementation
{
    public class ChatHistorialRepository : Repository<ChatHistorial>, IChatHistorialRepository
    {

        public readonly ApplicationDbContext dbContext;

        public ChatHistorialRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

    }
}
