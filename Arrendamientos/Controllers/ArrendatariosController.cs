using Arrendamiento.Controllers.Base;
using Core.Models.Entities;
using Core.Services.Base.Interfaces;
using Core.Services.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Arrendamiento.Controllers
{
    public class ArrendatariosController : BaseController<Arrendatario, IArrendatarioService>
    {
        public ArrendatariosController(IArrendatarioService arrendatarioService) : base(arrendatarioService)
        {
        }
    }
}
