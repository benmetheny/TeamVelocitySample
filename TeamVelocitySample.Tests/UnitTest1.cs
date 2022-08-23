using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeamVelocitySample.Data;
using TeamVelocitySample.Repository;

namespace TeamVelocitySample.Tests
{
    [TestClass]
    public class ToDoRepositoryTest
    {
        private readonly ToDoDbContext _dbContext;

        private ToDoRepository CreateRepository()
        {
            var options = new DbContextOptionsBuilder<ToDoDbContext>();
            options.UseInMemoryDatabase("ToDoDb");
            return new ToDoRepository(new ToDoDbContext(options.Options));
        }
        [TestMethod]
        public void ShouldAdd()
        {
            using (var r = this.CreateRepository())
            {
                var newItemId = r.AddItem(new Data.Models.ToDoItem { Title = "Test Item", DueDate = DateTime.Now.AddDays(3) });
                Assert.IsTrue(newItemId > 0,"Item key value is not set.");
            }
        }

        [TestMethod]
        public void ShouldDelete()
        {
            using (var r = this.CreateRepository())
            {
                var beforeCount = r.GetAllItems().Count();
                var newItemId = r.AddItem(new Data.Models.ToDoItem { Title = "Test Item", DueDate = DateTime.Now.AddDays(3) });
                r.DeleteItem(newItemId);
                var afterCount = r.GetAllItems().Count();
                Assert.AreEqual(beforeCount, afterCount, "Item was not deleted correctly.");
            }
        }
    }
}
