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
    public interface IRepository<TEntity,TKey>
    {
        public IEnumerable<TEntity> GetAllItems();
        public TEntity GetItem(TKey key);
        public TKey AddItem(TEntity entity);
        public bool UpdateItem(TEntity entity);
        public bool DeleteItem(TKey key);
    }
}
