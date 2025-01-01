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

        [HttpGet]
        [Route("{target}/{deployKey}")]
        public async Task<IActionResult> Deploy( [FromRoute] TypeDeployEnum target, [FromRoute] string deployKey )
        {
            try
            {
                if(deployKey!="e753509f-f46e-4fd2-881a-2b1631ee0852")
                    return Problem("Not comes from valid origin");
                var response = await _deployService.Deploy(target);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}