namespace Al_Noor.Infrastructure.Repository
{
    public interface IGenericRepo<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includes);
        Task<T> AddAsync(T entity);
        void delete(T entity);  
    }
}
