using Core.DTOs;
using Core.Models.Entities;
using Core.Services.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Base.Implementations
{
    public class ServiceDocBase<TBaseEntity> : ServiceBase<TBaseEntity>, IServiceDocBase<TBaseEntity>
        where TBaseEntity : BaseEntity
    {
        protected IBaseHtmlToPdf _baseHtmlToPdf;


        public ServiceDocBase(IRepoBase<TBaseEntity> repoGenerico, IBaseHtmlToPdf baseHtmlToPdf) : base(repoGenerico)
        {
            _baseHtmlToPdf = baseHtmlToPdf;
        }

        public Task<DocumentResponseDto> CreateDocument(int id)
        {
            throw new NotImplementedException();
        }

       
    }
}
