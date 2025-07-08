﻿using MyApp.Domain.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> Find(BaseSpecification<TEntity> specification);
        void Add(TEntity entity);
        IEnumerable<TEntity> GetAll();
    }
}
