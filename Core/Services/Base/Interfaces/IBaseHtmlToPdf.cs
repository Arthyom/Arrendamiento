using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DTOs;

namespace Core.Services.Base.Interfaces
{
    public interface IBaseHtmlToPdf
    {
        public Task<DocumentResponseDto> CreatePdfFor<TDocTar>( params MarkerDtoCollection? [] markers);
    }
}
