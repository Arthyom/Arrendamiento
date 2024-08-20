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
    public class ArrendatarioService : ServiceBase<Arrendatario>, IArrendatarioService
    {
        public ArrendatarioService(IRepoBase<Arrendatario> repoGenerico) : base(repoGenerico)
        {
        }
    }
}
