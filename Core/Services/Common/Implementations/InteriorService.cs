using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Core.Models.Entities;
using Core.Services.Base.Implementations;
using Core.Services.Base.Interfaces;
using Core.Services.Common.Interfaces;

namespace Core.Services.Common.Implementations
{
    public class InteriorService : ServiceBase<Interior>, IInteriorService
    {
        public InteriorService(IRepoBase<Interior> repoGenerico) : base(repoGenerico)
        {
        }

        public async Task<IEnumerable<Interior>> GetAllByPropiedad(int propiedadId)
        {
            return await _repoGenerico.GetAllAsync( x => x.PropiedadId == propiedadId);
        }
    }
}