using WordPenca.Business.Persistence;
using WordPenca.Business.Domain;
using WordPenca.Business.Repository.Interface;


namespace WordPenca.Business.Repository.Implementation
{
    public class ChatRepository : Repository<Chat>, IChatRepository
    {

        public readonly ApplicationDbContext dbContext;

        public ChatRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
