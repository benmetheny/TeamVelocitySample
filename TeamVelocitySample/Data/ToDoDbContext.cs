using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TeamVelocitySample.Data.Models;

namespace TeamVelocitySample.Data
{
    public class ToDoDbContext : DbContext
    {
        public ToDoDbContext(DbContextOptions<ToDoDbContext> options):base(options)
        {

        }
        public DbSet<ToDoItem> ToDos { get; set; }
    }
}
