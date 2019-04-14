using System;
using System.Collections.Generic;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Interfaces.Repositories;
using Ecommerce.Infra.Data.Context;
using Ecommerce.Infra.Data.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infra.Data.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : BaseEntity
    {
        protected readonly EcommerceContext context;
        protected readonly DbSet<TEntity> dbSet;

        public BaseRepository(EcommerceContext context)
        {
            context = context;
            dbSet = context.Set<TEntity>();
        }

        public virtual void Add(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            dbSet.Remove(entity);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return dbSet;
        }

        public virtual TEntity GetById(int id)
        {
            return dbSet.Find(id);
        }

        public virtual void Update(TEntity entity)
        {
            dbSet.Update(entity);
        }
    }
}
