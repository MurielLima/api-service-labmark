using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Labmark.Domain.Shared.Infrastructure.EFCore.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        public Task<TEntity> GetByID(int id);

        public Task<IList<TEntity>> Get(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");

        public bool Insert(TEntity entity);
        public bool Save(TEntity entity);

        public bool Delete(TEntity entity);
        public Task<bool> Commit();
        public Task<bool> Rollback();
    }
}
