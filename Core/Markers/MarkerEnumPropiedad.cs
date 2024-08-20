using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Markers
{
    public enum MarkerEnumPropiedad
    {
        [Description("${Propiedad.Nombre}")]
        PropiedadNombre,

        [Description("${Propiedad.Direccion}")]
        PropiedadDireccion,

        [Description("${Propiedad.Municipio}")]
        PropiedadMunicipio,

        [Description("${Propiedad.Colonia}")]
        PropiedadColonia,

       [Description("${Propiedad.Precio}")]
        PropiedadPrecio,
    }
}
