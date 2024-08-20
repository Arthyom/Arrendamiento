using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class DocumentResponseDto
    {
        public string NameAndExtension { get; set; } = string.Empty;

        public string ContentType { get; set; } = string.Empty;

        public byte[] Data { get; set; } = new byte[0];
    }
}
