using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace EFDemo.DAL.Repositories
{
    public class Repository<S, T> : IRepository<S> where S : class where T : DbContext
    {

        protected T context;

        public Repository(T context)
        {
            this.context = context;
        }

        public void Create(S entity)
        {
            context.Set<S>().Add(entity);
            context.SaveChanges();
        }

        public void Update(S entity)
        {
            context.Set<S>().Update(entity);
            context.SaveChanges();
        }

        public void Delete(S entity)
        {
            context.Set<S>().Remove(entity);
            context.SaveChanges(true);
        }

        public IQueryable<S> FindAll() => context.Set<S>().AsNoTracking();

        public IQueryable<S> FindByCondition(Expression<Func<S, bool>> expression) => context.Set<S>().Where(expression).AsNoTracking();

    }
}
