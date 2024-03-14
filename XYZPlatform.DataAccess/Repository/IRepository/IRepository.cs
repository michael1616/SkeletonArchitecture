using System.Linq.Expressions;

namespace XYZPlatform.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetById(int id);

        Task<List<T>> GetAll(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>,
            IOrderedQueryable<T>> orderBy = null,
            string includeProperties = null
            );

        Task<T> GetFirstOrDefault(
             Expression<Func<T, bool>> filter = null,
             string includeProperties = null,
             bool tracked = true
            );

        Task Add(T entity);

        Task Remove(int id);

        void Remove(T entity);
    }
}
