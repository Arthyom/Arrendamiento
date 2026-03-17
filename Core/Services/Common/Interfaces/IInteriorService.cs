using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Models.Entities;
using Core.Services.Base.Interfaces;

namespace Core.Services.Common.Interfaces
{
    public interface IInteriorService : IServiceBase<Interior>
    {
        public Task<IEnumerable<Interior>> GetAllByPropiedad(int propiedadId);
    }
}