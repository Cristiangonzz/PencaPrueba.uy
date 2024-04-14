
using WordPenca.Business.Domain;

namespace WordPenca.Business.Service
{
    public interface ICampionatoRepository
    {
        Task<Campionato> CreateAsync(Campionato entity);
        Task<Campionato> GetAll();
        Task<List<Campionato>> GetById(Guid Id);
    }
}
