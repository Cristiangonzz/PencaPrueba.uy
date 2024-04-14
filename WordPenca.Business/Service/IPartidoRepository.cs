
using WordPenca.Business.Domain;

namespace WordPenca.Business.Service
{
    public interface IPartidoRepository
    {
        Task<Partido> CreateAsync(Partido entity);
        Task<Partido> GetAll();
        Task<List<Partido>> GetById(Guid Id);
    }
}
