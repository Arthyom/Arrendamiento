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
    public class PropiedadService : ServiceBase<Propiedad>, IPropiedadService
    {
        public PropiedadService(IRepoBase<Propiedad> repoGenerico) : base(repoGenerico)
        {
        }

        public async new  Task<IEnumerable<Propiedad>?> GetAllAsync()
        {
            var s= await _repoGenerico.createInstance<Propiedad>()
                            ._entity
                            .Include(p => p.Interiores)
                     
                    
                            
                            
                          
                            
                            .ToListAsync();



           return s;
        }

        public async new Task<Propiedad?> GetByIdAsync(int id)
        {
            return await _repoGenerico.createInstance<Propiedad>()
                            ._entity
                            .AsQueryable()
                            .Where( x => x.Id == id )
                            .Include( A => A.Interiores)
                            // .ThenInclude( i => i.Propiedad )
                            // .AsNoTracking(  )
                            .FirstOrDefaultAsync();
        }
    }
}
