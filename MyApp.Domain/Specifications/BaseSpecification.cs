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
        public Expression<Func<TEntity, bool>>? Criteria { get; protected set; }

        public List<Expression<Func<TEntity, object>>> Includes { get; } = new();

        public Expression<Func<TEntity, object>>? OrderBy { get; protected set; }
        public Expression<Func<TEntity, object>>? OrderByDescending { get; protected set; }

        public int Take { get; protected set; }
        public int Skip { get; protected set; }
        public bool IsPagingEnabled { get; protected set; }

        protected BaseSpecification() { }

        protected BaseSpecification(Expression<Func<TEntity, bool>> criteria)
        {
            Criteria = criteria;
        }

        protected void AddInclude(Expression<Func<TEntity, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }

        protected void ApplyOrderBy(Expression<Func<TEntity, object>> orderByExpression)
        {
            OrderBy = orderByExpression;
        }

        protected void ApplyOrderByDescending(Expression<Func<TEntity, object>> orderByDescExpression)
        {
            OrderByDescending = orderByDescExpression;
        }

        protected void ApplyPaging(int skip, int take)
        {
            Skip = skip;
            Take = take;
            IsPagingEnabled = true;
        }
    }
}