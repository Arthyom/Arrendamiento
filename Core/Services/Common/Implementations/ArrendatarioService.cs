using Core.Models.Entities;
using Core.Services.Base.Implementations;
using Core.Services.Base.Interfaces;
using Core.Services.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
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

        public async new  Task<IEnumerable<Arrendatario>?> GetAllAsync()
        {
            return await _repoGenerico.createInstance<Arrendatario>()
                            ._entity
                            .AsQueryable()
                            .Include( A => A.Interiores)
                            .ThenInclude( i => i.Propiedad )
                            .AsNoTracking(  )
                            .ToListAsync();
        }


        public async new Task<Arrendatario?> GetByIdAsync(int id)
        {
            return await _repoGenerico.createInstance<Arrendatario>()
                            ._entity
                            .AsQueryable()
                            .Where( x => x.Id == id )
                            .Include( A => A.Interiores)
                            .ThenInclude( i => i.Propiedad )
                            .AsNoTracking(  )
                            .FirstOrDefaultAsync();
        }

    }
}
