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

    public abstract class BaseRepositoryController<TEntity,TKey> : ControllerBase {
        private readonly IRepository<TEntity,TKey> _repository;

        public BaseRepositoryController(IRepository<TEntity,TKey> repository)
        {
            this._repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TEntity>> GetAll()
        {
            return Ok(_repository.GetAllItems());
        }

        [HttpGet]
        [Route("{key}")]
        public ActionResult<TEntity> GetByKey([FromRoute]TKey key)
        {
            return Ok(_repository.GetItem(key));
        }

        [HttpPost]
        public ActionResult Post([FromBody]TEntity entity)
        {
            var key = _repository.AddItem(entity);
            return CreatedAtAction(nameof(GetByKey), new { key = key }, key);
        }

        [HttpPut]
        public ActionResult<bool> Update([FromBody]TEntity entity)
        {
            _repository.UpdateItem(entity);
            return Ok(true);
        }

        [HttpDelete]
        [Route("{key}")]
        public ActionResult<bool> Delete([FromRoute]TKey key)
        {
            _repository.DeleteItem(key);
            return Ok(true);
        }
    }

}
