using MyApp.Domain.Repositories;
using MyApp.Domain.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Infrastructure.Repositories
{
    public class InMemoryRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly List<TEntity> _entities = new();

        public IEnumerable<TEntity> Find(BaseSpecification<TEntity> specification)
        {
            return _entities.AsQueryable().Where(specification.Criteria);
        }

        public void Add(TEntity entity)
        {
            _entities.Add(entity);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _entities;
        }
    }
}
