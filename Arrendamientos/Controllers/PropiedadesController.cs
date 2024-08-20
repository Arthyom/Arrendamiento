using Arrendamiento.Controllers.Base;
using Core.Models.Entities;
using Core.Services.Base.Interfaces;
using Core.Services.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Arrendamiento.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropiedadesController : BaseController<Propiedad, IPropiedadService>
    {
        public PropiedadesController(IPropiedadService PropiedadService) : base(PropiedadService)
        {
        }
    }
}
