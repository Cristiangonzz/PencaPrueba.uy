using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WordPenca.Business.Persistence;
using WordPenca.Business.Service;
using WordPenca.Business.Domain;

namespace WordPenca.Business.Repository
{
    public class EquipoRepository : IEquipoRepository
    {

        public readonly ApplicationDbContext dbContext;

        public EquipoRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> Update(Equipo entity)
        {
            try
            {
                dbContext.Update(entity);
                await dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Equipo> Create(Equipo entity)
        {
            try
            {
                dbContext.Set<Equipo>().Add(entity);
                await dbContext.SaveChangesAsync();
                return entity;
            }
            catch
            {
                throw;
            }
        }



        public async Task<List<Equipo>> GetAll()
        {
            try
            {
                return await dbContext.Equipos.ToListAsync();
            }
            catch
            {
                throw;
            }
        }


        public async Task<Equipo> GetById(Guid Id)
        {



            throw new NotImplementedException();
        }

        public async Task<bool> Delete(Equipo entity)
        {
            try
            {
                dbContext.Remove(entity);
                await dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Equipo> Obtener(Expression<Func<Equipo, bool>> filtro = null)
        {
            try
            {
                return await dbContext.Equipos.Where(filtro).FirstOrDefaultAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<IQueryable<Equipo>> Consultar(Expression<Func<Equipo, bool>> filtro = null)
        {
            IQueryable<Equipo> queryEntidad = filtro == null ? dbContext.Equipos : dbContext.Equipos.Where(filtro);
            return queryEntidad;
        }
    }
}
