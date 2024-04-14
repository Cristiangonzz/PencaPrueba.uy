
using WordPenca.Business.Domain;

namespace WordPenca.Business.Service
{
    public interface ITablaRepository
    {
        Task<Tabla> CreateAsync(Tabla entity);
        Task<Tabla> GetAll();
        Task<List<Tabla>> GetById(Guid Id);
    }
}
