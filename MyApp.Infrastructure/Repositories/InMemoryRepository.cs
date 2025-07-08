using Microsoft.EntityFrameworkCore;
using MyApp.Domain.Repositories;
using MyApp.Domain.Specifications;
using MyApp.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Infrastructure.Repositories
{
    public class EfRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public EfRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public IEnumerable<TEntity> Find(BaseSpecification<TEntity> specification)
        {
            return _dbSet.Where(specification.Criteria).AsNoTracking().ToList();
        }
    }
}
 
