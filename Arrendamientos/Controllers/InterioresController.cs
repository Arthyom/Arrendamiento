using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arrendamiento.Controllers.Base;
using Core.Models.Entities;
using Core.Services.Base.Interfaces;
using Core.Services.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Arrendamientos.Controllers
{

    public class InterioresController : BaseController<Interior, IInteriorService>
    {
        IInteriorService _interiorService;
        public InterioresController(IInteriorService interiorService) : base(interiorService)
        {
            this._interiorService = interiorService;
        }


        [HttpGet("GetAllByPropiedad/{propiedadId}")]
        public async Task<IActionResult> GetAllByPropiedad([FromRoute] int propiedadId)
        {
            var result = await _interiorService.GetAllByPropiedad(propiedadId);
            return Ok(result);  
        }
    }
}