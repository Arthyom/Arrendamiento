using Core.Helpers;
using Core.Models.Entities;
using Core.Services.Base.Implementations;
using Core.Services.Base.Interfaces;
using Core.Services.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Common.Implementations
{
    public class ArrendadorService : ServiceBase<Arrendador>, IArrendadorService
    {
        public ArrendadorService(IRepoBase<Arrendador> repoGenerico) : base(repoGenerico)
        {
        }

        

    }
}
