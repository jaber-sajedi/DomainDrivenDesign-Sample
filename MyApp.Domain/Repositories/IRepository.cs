using MyApp.Domain.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();

        TEntity? GetById(Guid id);

        void Add(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);

        Task<TEntity?> GetByIdAsync(Guid id);

        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> Find(BaseSpecification<TEntity> specification);
    }

}
