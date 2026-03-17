using Arrendamiento.Controllers.Base;
using Core.Models.Entities;
using Core.Services.Base.Interfaces;
using Core.Services.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Arrendamiento.Controllers
{
    public class RecibosController : BaseDocController<Recibo, IReciboService>
    {
        IReciboService _reciboService;
        public RecibosController
            (IReciboService ReciboService) : base(ReciboService)
        {
            _reciboService = ReciboService;
        }


        [HttpPut]
        public async Task<IActionResult> Put( Recibo  toCreate)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _serviceBase.Begin();
                    var response = await _reciboService.CreateSingle( toCreate );
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



    }
}
