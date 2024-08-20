using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Markers
{
    public enum MarkerEnumContrato
    {
        [Description("${Contrato.Inicio}")]
        ContratoFechaCorta,

        [Description("${Contrato.Inicio.FechaLarga}")]
        ContratoFechaLarga,

        [Description("${Contrato.Termino}")]
        ContratoFechaTermino,
    }
}
