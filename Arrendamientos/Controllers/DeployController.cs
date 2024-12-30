using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arrendamiento.Controllers.Base;
using Core.Enums;
using Core.Models.Entities;
using Core.Services.Base.Interfaces;
using Core.Services.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Arrendamientos.Controllers
{

    public class DeployController : BaseController<Deploy, IDeployService>
    {
        private readonly IDeployService _deployService;

        public DeployController(IDeployService serviceBase) : base(serviceBase)
        {
            _deployService = serviceBase;
        }

        [HttpPost]
        [Route("{target}")]
        public async Task<IActionResult> Deploy( [FromRoute] TypeDeployEnum target, [FromBody] Deploy? deploy )
        {
            try
            {
                var response = await _deployService.Deploy(target);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpGet]
        [Route("Saludar")]
        public async Task<IActionResult> Saludar(  )
        {
            try
            {
                return Ok( await Task.FromResult( "Hola este" ));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}