using Arrendamiento.Controllers.Base;
using Core.Models.Entities;
using Core.Services.Base.Interfaces;
using Core.Services.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Arrendamiento.Controllers
{
    public class RecibosController : BaseDocController<Recibo, IReciboService>
    {
        public RecibosController
            (IReciboService ReciboService) : base(ReciboService)
        {
        }
    }
}
