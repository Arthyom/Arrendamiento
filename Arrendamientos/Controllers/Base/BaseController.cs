using Core.Models.Entities;
using Core.Services.Base.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IActionResult> Get()
        {
            try
            {
                var response = await _serviceBase.GetAllAsync();
                return Ok(response);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

      

        // GET api/<PropiedadesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var response = await _serviceBase.GetByIdAsync(id);
                return Ok(response);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        // POST api/<PropiedadesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TBaseEntity toCreate)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _serviceBase.Begin();
                    var response = await _serviceBase.CreateAsync(toCreate);
                    _serviceBase.Commit();
                    return Ok(response);
                }
                return BadRequest();
            }
            catch (Exception e)
            {
                _serviceBase.RollBack();
                return Problem(e.Message);
            }
        }

        // PUT api/<PropiedadesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] TBaseEntity toUpdate)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _serviceBase.Begin();
                    var response = await _serviceBase.UpdateAsync(id, toUpdate);
                    _serviceBase.Commit();
                    return Ok(response);
                }
                return BadRequest();
            }
            catch (Exception e)
            {
                _serviceBase.RollBack();
                return Problem(e.Message);
            }
        }

        // DELETE api/<PropiedadesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {

                _serviceBase.Begin();
                var response = await _serviceBase.DeleteAsync(id);
                _serviceBase.Commit();
                return Ok(response);

            }
            catch(DbUpdateException dbE){
                 _serviceBase.RollBack();
                return Problem(dbE.Message, "Db interaction error");
            }
            catch (Exception e)
            {
                _serviceBase.RollBack();
                return Problem(e.Message);
            }
        }
    }
}
