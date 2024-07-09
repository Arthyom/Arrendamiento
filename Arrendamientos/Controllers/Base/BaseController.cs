using Core.Models.Entities;
using Core.Services.Base.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Arrendamiento.Controllers.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<TBaseEntity, TServiceBase> : ControllerBase
        where TBaseEntity : BaseEntity
        where TServiceBase : IServiceBase<TBaseEntity>
    {
        protected IServiceBase<TBaseEntity> _serviceBase;

        public BaseController(IServiceBase<TBaseEntity> serviceBase)
        {

            _serviceBase = serviceBase;

        }


        // GET: api/<PropiedadesController>
        [HttpGet]
        public async Task<IEnumerable<TBaseEntity>?> Get()
        {
            return await _serviceBase.GetAllAsync();
        }

        // GET api/<PropiedadesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PropiedadesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PropiedadesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PropiedadesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
