using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class MarkerDto
    {
        public string key { get; set; } = string.Empty;

        public string name { get; set; } = string.Empty;

        public string? property { get; set; }

        public string? value { get; set; }

        public List< MarkerPropertyDto >? properties { get; set; }
    }
}
