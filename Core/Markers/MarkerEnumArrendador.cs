using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Markers
{
    public enum MarkerEnumArrendador
    {
        [Description("${Arrendador.Nombre}")]
        ArrendadorNombre,

        [Description("${Arrendador.Direccion}")]
        ArrendadorDireccion,

        [Description("${Arrendador.Municipio}")]
        ArrendadorMunicipio,

        [Description("${Arrendador.Colonia}")]
        ArrendadorColonia,
    }
}
