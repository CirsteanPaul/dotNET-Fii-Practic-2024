using System.Linq.Expressions;

namespace RepositoryPattern.Database.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        bool Any(Expression<Func<TEntity, bool>> where);
        int Count();
        int Count(Expression<Func<TEntity, bool>> where);
        IEnumerable<TEntity> GetAll();
        TEntity Find(int id);
        TEntity Find(string id);
        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entities);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
    }
}
