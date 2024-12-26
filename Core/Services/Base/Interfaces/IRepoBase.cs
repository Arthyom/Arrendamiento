using Core.Models.Entities;
using Core.Services.Base.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Base.Interfaces
{
    public interface IRepoBase<TBaseEntity> where TBaseEntity : BaseEntity
    {
        public Task<IEnumerable<TBaseEntity>> GetAllAsync(Expression<Func<TBaseEntity, bool>>? expresion = null );

        public Task<TBaseEntity?> GetAsync(Expression<Func<TBaseEntity, bool>>? expresion = null);

        public Task<int> CountAsync(Expression<Func<TBaseEntity, bool>>? expresion = null);

        public Task<TBaseEntity?> GetByIdAsync(int id);

        public Task<TBaseEntity?> CreateAsync(TBaseEntity toCreate);

        public Task<TBaseEntity?> UpdateAsync(int id, TBaseEntity toEdit);

        public Task<TBaseEntity?> DeleteAsync(TBaseEntity toDelete);

        public RepoBase<TInstance> createInstance<TInstance>() where TInstance : BaseEntity;

        public void Commit();
        public void Rollback();
        public void Begin();
        public void Dispose();
    }
}
