using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Core.Models.Context;
using Core.Models.Entities;
using Core.Services.Base.Interfaces;
using Arrendamiento.Controllers.Base;
using Core.Services.Common.Interfaces;

namespace Arrendamiento.Controllers
{
    public class ArrendadoresController : BaseController<Arrendador, IArrendadorService>
    {
        public ArrendadoresController
            (IArrendadorService ArrendadorService) : base(ArrendadorService)
        {
        }
    }
}
