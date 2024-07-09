using Core.Models.Entities;
using Core.Services.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Base.Implementations
{
    public class ServiceBase<TBaseEntity> : IServiceBase<TBaseEntity> where TBaseEntity : BaseEntity
    {
        protected IRepoBase<TBaseEntity> _repoGenerico;

        public ServiceBase(IRepoBase<TBaseEntity> repoGenerico)
        {
            _repoGenerico = repoGenerico;
        }

        public async Task<IEnumerable<TBaseEntity>?> GetAllAsync()
        {
            return await _repoGenerico.GetAllAsync();
        }

        public Task<TBaseEntity?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
