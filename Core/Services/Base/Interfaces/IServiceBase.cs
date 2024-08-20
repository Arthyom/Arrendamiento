using Core.DTOs;
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

        public Task<TBaseEntity?> CreateAsync(TBaseEntity toCreate);

        public Task<TBaseEntity?> UpdateAsync(int id, TBaseEntity toUpdate);

        public Task<bool> DeleteAsync(int id);

        public Task<MarkerDtoCollection?> GetMarkersAsync<TEntity>(int id) where TEntity : BaseEntity;

        public void RollBack();
        public void Commit();
        public void Begin();
    }
}
