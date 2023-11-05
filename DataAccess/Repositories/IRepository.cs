using System.Linq.Expressions;

namespace DataAccess.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<List<TEntity>> GetAllAsync(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");

        Task<TEntity> GetByIdAsync(object id);

        Task InsertAsync(TEntity entity);

        Task DeleteAsync(object id);

        void Delete(TEntity entityToDelete);

        void Update(TEntity entityToUpdate);

        Task SaveAsync();
    }
}