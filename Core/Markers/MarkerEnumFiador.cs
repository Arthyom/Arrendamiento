using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Markers
{
    public enum MarkerEnumFiador
    {
        [Description("${Fiador.Nombre}")]
        FiadorNombre,

        [Description("${Fiador.Direccion}")]
        FiadorDireccion,

        [Description("${Fiador.Municipio}")]
        FiadorMunicipio,

        [Description("${Fiador.Colonia}")]
        FiadorColonia
    }
}
