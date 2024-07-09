using Arrendamiento.Controllers.Base;
using Core.Models.Entities;
using Core.Services.Base.Interfaces;
using Core.Services.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Arrendamiento.Controllers
{
    public class FiadoresController : BaseController<Fiador, IFiadorService>
    {
        public FiadoresController(IFiadorService serviceBase) : base(serviceBase)
        {
        }

        //[HttpGet(Order = -1)]
        //public new IEnumerable<string> Get()
        //{
        //    return new string[] { "logica sobre escrita", "en controlador hijo" };
        //}
    }
}
