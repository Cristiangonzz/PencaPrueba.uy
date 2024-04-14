

namespace WordPenca.Business.Service
{
    public interface IBaseRepository
    {
        Task <T> CreateAsync<T> (T entity);
        Task<T> GetAll<T>();
        Task<T> GetById<T>(Guid Id);
        //Task<T> UpdateAsync<T> (T entity, bool update);

    }
}
