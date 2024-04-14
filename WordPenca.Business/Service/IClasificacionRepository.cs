
using WordPenca.Business.Domain;

namespace WordPenca.Business.Service
{
    public interface IClasificacionRepository
    {
        Task<Clasificacion> CreateAsync(Clasificacion entity);
        Task<Clasificacion> GetAll();
        Task<List<Clasificacion>> GetById(Guid Id);
    }
}
