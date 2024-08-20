using Core.DTOs;
using Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Base.Interfaces
{
    public interface IServiceDocBase<TBaseEntity> : IServiceBase<TBaseEntity>
        where TBaseEntity : BaseEntity
    {
        public Task<DocumentResponseDto> CreateDocument(int id);
    }
}
