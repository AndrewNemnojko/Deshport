namespace Deshport.DAL.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task Create(T entity);
        Task Delete(T entity);
        Task Change(T entity);
        IQueryable<T> GetAll();
    }
}
