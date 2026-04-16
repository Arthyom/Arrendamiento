using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Core.Models.Entities;
using Core.Services.Base.Implementations;
using Core.Services.Base.Interfaces;
using Core.Services.Common.Interfaces;
using Humanizer;
using Microsoft.EntityFrameworkCore;

namespace Core.Services.Common.Implementations
{
    public class InteriorService : ServiceBase<Interior>, IInteriorService
    {
        public InteriorService(IRepoBase<Interior> repoGenerico) : base(repoGenerico)
        {
        }


        public async new  Task<IEnumerable<Interior>?> GetAllAsync()
        {
            return await _repoGenerico.createInstance<Interior>()
                            ._entity
                            .AsQueryable()
                            .Include( A => A.Propiedad)
                            .Include( A => A.Arrendatario)
                            .AsNoTracking(  )
                            .ToListAsync();
        }



        public async Task<IEnumerable<Interior>> GetAllByPropiedad(int propiedadId)
        {
            return await _repoGenerico.GetAllAsync( x => x.PropiedadId == propiedadId);
        }

         public async new Task<Interior?> GetByIdAsync(int id)
        {
            return await _repoGenerico.createInstance<Interior>()
                            ._entity
                            .AsQueryable()
                            .Where( x => x.Id == id )
                            // .Include( A => A.Interiores)
                            .Include( i => i.Propiedad )
                            .Include( i => i.Arrendatario )
                            .AsNoTracking(  )
                            .FirstOrDefaultAsync();
        }


    }
}