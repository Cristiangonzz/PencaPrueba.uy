using WordPenca.Business.Persistence;
using WordPenca.Business.Domain;
using WordPenca.Business.Repository.Implementation;
using WordPenca.Business.Repository.Interface;

namespace WordPenca.Business.Repository.Implementation
{
    public class ChatMensajeRepository : Repository<ChatMensaje>, IChatMensajeRepository
    {

        public readonly ApplicationDbContext dbContext;

        public ChatMensajeRepository(ApplicationDbContext dbContext):base(dbContext)
        {
            this.dbContext = dbContext;
        }

    }
}
