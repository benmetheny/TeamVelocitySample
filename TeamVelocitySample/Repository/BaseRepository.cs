using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TeamVelocitySample.Data;
using TeamVelocitySample.Data.Models;

namespace TeamVelocitySample.Repository
{
    public abstract class BaseRepository<TEntity, TKey> : IDisposable, IRepository<TEntity, TKey> where TEntity:class
    {
        protected readonly DbContext Context;

        protected BaseRepository(DbContext context) {
            this.Context = context;
        }
        protected abstract TKey GetKeyValue(TEntity entity);
        public TKey AddItem(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
            Context.SaveChanges();
            return this.GetKeyValue(entity);
        }

        public bool DeleteItem(TKey key)
        {
            Context.Set<TEntity>().Remove(this.GetItem(key));
            Context.SaveChanges();
            return true;
        }

        public IEnumerable<TEntity> GetAllItems()
        {
            return Context.Set<TEntity>();
        }

        public abstract TEntity GetItem(TKey key);

        public bool UpdateItem(TEntity entity)
        {
            Context.Set<TEntity>().Attach(entity);
            Context.SaveChanges();
            return true;
        }

        public void Dispose()
        {
            this.Context.Dispose();
        }
    }
}
