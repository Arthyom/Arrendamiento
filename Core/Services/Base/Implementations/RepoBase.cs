using Core.Models.Entities;
using Core.Services.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Base.Implementations
{
    public class RepoBase<TBaseEntity> : IRepoBase<TBaseEntity> where TBaseEntity : BaseEntity
    {
        public async Task<IEnumerable<TBaseEntity>?> GetAllAsync()
        {
            return await Task.Run(() =>
            {
                return new List<TBaseEntity>() { };
            });
        }

        public Task<TBaseEntity?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
