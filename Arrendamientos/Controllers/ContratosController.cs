using Arrendamiento.Controllers.Base;
using Core.Models.Entities;
using Core.Services.Base.Interfaces;
using Core.Services.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Arrendamiento.Controllers
{
    public class ContratosController : BaseDocController<Contrato, IContratoService>
    {
        public ContratosController
            (IContratoService ContratoService) : base(ContratoService)
        {
        }
    }
}
