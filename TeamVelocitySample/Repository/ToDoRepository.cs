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
    public class ToDoRepository : BaseRepository<ToDoItem, int>
    {
        public ToDoRepository(ToDoDbContext context):base(context)
        {

        }
        public override ToDoItem GetItem(int key)
        {
            return Context.Set<ToDoItem>().FirstOrDefault(i => i.ToDoItemId == key);
        }

        protected override int GetKeyValue(ToDoItem entity)
        {
            return entity.ToDoItemId;
        }
    }
}
