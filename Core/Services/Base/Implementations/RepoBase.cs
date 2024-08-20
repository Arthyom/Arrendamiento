using Core.Models.Context;
using Core.Models.Entities;
using Core.Services.Base.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Base.Implementations
{
    public class RepoBase<TBaseEntity> : IDisposable, IRepoBase<TBaseEntity> where TBaseEntity : BaseEntity
    {
        private readonly ArrendamientoContext _context;
        private readonly DbSet<TBaseEntity> _entity;
        private IDbContextTransaction? _objTran;
        private bool _disposed;


        public RepoBase(ArrendamientoContext context)
        {
            _context = context;
            _entity = _context.Set<TBaseEntity>();
            _disposed = false;
            _objTran = null;

        }

        public RepoBase<TInstance> createInstance<TInstance>() where TInstance : BaseEntity
        {
            return new RepoBase<TInstance>(_context);
        }


        public async Task<IEnumerable<TBaseEntity>> GetAllAsync(Expression<Func<TBaseEntity, bool>>? predicate)
        {
            if (predicate != null)
                return await _entity.Where(predicate).ToListAsync();

            return await _entity.ToListAsync();
        }

        public Task<TBaseEntity?> GetAsync(Expression<Func<TBaseEntity, bool>>? expresion = null)
        {
            throw new NotImplementedException();
        }

        public async Task<TBaseEntity?> GetByIdAsync(int id)
        {
            return await _entity.FirstOrDefaultAsync(x => x.Id == id);
        }


        public async Task<TBaseEntity?> UpdateAsync(int id, TBaseEntity toEdit)
        {
            toEdit.UpdatedAt = DateTime.Now;
            toEdit.UpdatedBy = 2;

            _entity.Update(toEdit);
            await _context.SaveChangesAsync();

            return toEdit;
        }

        public Task<int> CountAsync(Expression<Func<TBaseEntity, bool>>? expresion = null)
        {
            throw new NotImplementedException();
        }

        public async Task<TBaseEntity?> CreateAsync(TBaseEntity toCreate)
        {
            toCreate.CreatedAt = DateTime.Now;
            toCreate.CreatedBy = 1;

            _entity.Add(toCreate);
            await _context.SaveChangesAsync();

            return toCreate;
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }



        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Commit()
        {
            if (_objTran != null)
                _objTran.Commit();
        }

        public void Rollback()
        {
            if (_objTran != null)
            {
                _objTran.Rollback();
                _objTran.Dispose();
            }
        }

        public void Begin()
        {
            _objTran = _context.Database.BeginTransaction();
        }


        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }

            _disposed = true;
        }

    }
}
