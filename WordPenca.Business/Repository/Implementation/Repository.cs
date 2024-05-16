using WordPenca.Business.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using WordPenca.Business.Persistence;
using System.Linq.Expressions;


namespace WordPenca.Business.Repository.Implementation
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;

        public Repository(ApplicationDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
        }

        async Task<IEnumerable<T>> IRepository<T>.GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null)
        {
            IQueryable<T> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return await query.ToListAsync();
        }

        public async Task<T> GetFirstOrDefault(System.Linq.Expressions.Expression<Func<T, bool>> filter, string? includeProperties = null, bool tracked = false)
        {
            IQueryable<T> query = tracked ? dbSet : dbSet.AsNoTracking();
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return await query.Where(filter).FirstOrDefaultAsync();
        }

        async Task<T> IRepository<T>.Add(T entity)
        {
           

            try
            {
                var entitydb = await dbSet.AddAsync(entity);
                return entitydb.Entity;
            }
            catch (Exception ex)
            {
                // Maneja cualquier excepción y devuelve false
                Console.WriteLine($"Error al eliminar la entidad: {ex.Message}");
                throw;
            }
        }

        async Task<bool> IRepository<T>.Remove(T entity)
        {
            try
            {
                // Intenta eliminar la entidad
                var removedEntity = dbSet.Remove(entity);
                return removedEntity.Entity != null; // Devuelve true si la entidad eliminada no es nula
            }
            catch (Exception ex)
            {
                // Maneja cualquier excepción y devuelve false
                Console.WriteLine($"Error al eliminar la entidad: {ex.Message}");
                return false;
            }
        }

        async Task<bool> IRepository<T>.RemoveRange(IEnumerable<T> entities)
        {
           
            try
            {
                dbSet.RemoveRange(entities);
                return true; 
            }
            catch (Exception ex)
            {
                // Maneja cualquier excepción y devuelve false
                Console.WriteLine($"Error al eliminar las entidades : {ex.Message}");
                return false;
            }
        }

        async Task<T> IRepository<T>.Update(T entity)
        {
           

            try
            {
                dbSet.Update(entity);
                return entity;
            }
            catch (Exception ex)
            {
                // Maneja cualquier excepción y devuelve false
                Console.WriteLine($"Error al Editar la entidad : {ex.Message}");
                throw;
            }
        }
    }
}
