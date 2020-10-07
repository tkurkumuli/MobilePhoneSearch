using BusinessLayer.Models;
using BusinessLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BusinessLayer.Implementations
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext context;
        public Repository(DbContext context) => this.context = context;

        public virtual IEnumerable<TEntity> Get() => context.Set<TEntity>().ToList();
        public virtual IEnumerable<TEntity> Get(MobilePhoneListFilterModel filter) =>
       context.Set<TEntity>().ToList();
    }
}
