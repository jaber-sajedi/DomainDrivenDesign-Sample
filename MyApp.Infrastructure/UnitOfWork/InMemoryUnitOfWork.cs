using MyApp.Domain.Repositories;
using MyApp.Domain.UnitOfWork;
using MyApp.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Infrastructure.UnitOfWork
{
    public class InMemoryUnitOfWork : IUnitOfWork
    {
        private readonly Dictionary<Type, object> _repositories = new();

        public IRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            var type = typeof(TEntity);
            if (!_repositories.ContainsKey(type))
            {
                var repositoryInstance = new InMemoryRepository<TEntity>();
                _repositories.Add(type, repositoryInstance);
            }

            return (IRepository<TEntity>)_repositories[type];
        }

        public void Commit()
        {
            // In-Memory است و نیازی به Commit واقعی نیست
            Console.WriteLine("Changes committed (In-Memory)");
        }
    }
}
