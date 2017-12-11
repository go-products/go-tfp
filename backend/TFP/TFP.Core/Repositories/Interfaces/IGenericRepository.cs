using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace TFP.Core.Repositories.Interfaces
{
    public interface IGenericRepository<TEntity> : IDisposable
          where TEntity : class
    {
        IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");

        TEntity GetById(object id);

        void Add(TEntity entity);

        void AddRange(IEnumerable<TEntity> entities);

        void DeleteRange(IEnumerable<TEntity> entities);

        void Delete(object id);

        void Delete(TEntity entityToDelete);

        void Update(TEntity entityToUpdate);

        IEnumerable<TEntity> GetPage<TOrderBy>(int page, int entitiesOnPage,
            Expression<Func<TEntity, TOrderBy>> orderExpression, bool descending = false, string includeProperties = "");

        int GetCount();
    }
}
