using System.Linq.Expressions;
using WordPenca.Business.Domain;

namespace WordPenca.Business.Service
{
    public interface IEquipoRepository
    {
        Task<Equipo> Create(Equipo entity);
        Task<bool> Update(Equipo entity);

        Task<Equipo> Obtener(Expression<Func<Equipo, bool>> filtro = null);

        Task<bool> Delete(Equipo entidad);


        Task<IQueryable<Equipo>> Consultar(Expression<Func<Equipo, bool>> filtro = null);
    }
}
