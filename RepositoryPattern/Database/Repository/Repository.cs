using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace RepositoryPattern.Database.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly AppDbContext Context;

        protected Repository(AppDbContext context)
        {
            Context = context;
        }
        
        public bool Any(Expression<Func<TEntity, bool>> where)
        {
            return Context.Set<TEntity>().Where(where).Any();
        }

        public int Count()
        {
            return Context.Set<TEntity>().Count();
        }

        public int Count(Expression<Func<TEntity, bool>> where)
        {
            return Context.Set<TEntity>().Where(where).Count();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Context.Set<TEntity>().ToList();
        }

        public TEntity Find(int id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        public TEntity Find(string id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().SingleOrDefault(predicate);
        }

        public void Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().AddRange(entities);
        }

        public void Update(TEntity entity)
        {
            Context.Set<TEntity>().Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
        }


        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().UpdateRange(entities);
        }

        public void Remove(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().RemoveRange(entities);
        }
    }
}
