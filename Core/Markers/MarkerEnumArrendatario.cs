using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Markers
{
    public enum MarkerEnumArrendatario
    {
        [Description("${Arrendatario.Nombre}")]
        ArrendatarioNombre,

        [Description("${Arrendatario.Direccion}")]
        ArrendatarioDireccion,

        [Description("${Arrendatario.Municipio}")]
        ArrendatarioMunicipio,

        [Description("${Arrendatario.Colonia}")]
        ArrendatarioColonia,
    }
}
