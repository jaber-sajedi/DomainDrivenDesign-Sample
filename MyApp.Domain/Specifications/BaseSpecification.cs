using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.Specifications
{
    public abstract class BaseSpecification<TEntity>
    {
        public Expression<Func<TEntity, bool>> Criteria { get; }

        protected BaseSpecification(Expression<Func<TEntity, bool>> criteria)
        {
            Criteria = criteria;
        }
    }
}
