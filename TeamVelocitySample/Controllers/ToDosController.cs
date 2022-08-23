using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TeamVelocitySample.Data.Models;
using TeamVelocitySample.Repository;

namespace TeamVelocitySample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToDosController : BaseRepositoryController<ToDoItem, int>
    {
        public ToDosController(IRepository<ToDoItem, int> repository) : base(repository)
        {
        }
    }

}
