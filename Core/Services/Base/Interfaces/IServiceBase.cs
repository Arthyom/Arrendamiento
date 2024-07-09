using Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Base.Interfaces
{
    public interface IServiceBase<TBaseEntity> where TBaseEntity : BaseEntity
    {
        public Task<IEnumerable<TBaseEntity>?> GetAllAsync();
        public Task<TBaseEntity?> GetByIdAsync(int id);
    }
}
