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

    public class DeployController : BaseController<Deploy, IDeployService>
    {
        public DeployController(IDeployService serviceBase) : base(serviceBase)
        {
        }
    }
}