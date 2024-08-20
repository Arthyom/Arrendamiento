using Core.DTOs;
using Core.Helpers;
using Core.Models.Entities;
using Core.Services.Base.Implementations;
using Core.Services.Base.Interfaces;
using Core.Services.Common.Interfaces;
using Humanizer;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Common.Implementations
{
	public class ContratoService : ServiceDocBase<Contrato>, IContratoService
	{
		public ContratoService(IRepoBase<Contrato> repoGenerico, IBaseHtmlToPdf doc) : base(repoGenerico, doc)
		{
		}

		public new async Task<DocumentResponseDto> CreateDocument(int id)
		{
			var contrato = await _repoGenerico.GetByIdAsync(id);

			if (contrato != null)
			{
				var i = await GetMarkersAsync<Contrato>(id);
				var a = await GetMarkersAsync<Arrendador>(contrato.ArrendadorId);
				var s = await GetMarkersAsync<Arrendatario>(contrato.ArrendatarioId);
				var f = await GetMarkersAsync<Fiador>(contrato.FiadorId);
				var p = await GetMarkersAsync<Propiedad>(contrato.PropiedadId);

				if (i == null || a == null || s == null || f == null || p == null)
					throw new NotImplementedException();


				if (i.markers != null && a.markers != null && s.markers != null && f.markers != null && p.markers != null)
				{
					int fechaInicioMesDiaIndex = i.markers.FindIndex(x => x.name == "ContratoFechaInicioMesDia");
					int fechaTerminoMesDiaIndex = i.markers.FindIndex(x => x.name == "ContratoFechaTerminoMesDia");
					int fechaInicioLargaIndex = i.markers.FindIndex(x => x.name == "ContratoFechaInicioLarga");
					int precioTextoIndex = p.markers.FindIndex(x => x.name == "PropiedadPrecioTexto");
					int precioIndex = p.markers.FindIndex(x => x.name == "PropiedadPrecio");

					i.markers[fechaInicioLargaIndex].value = contrato.CreatedAt.ToDateFormat();
					i.markers[fechaInicioMesDiaIndex].value = contrato.CreatedAt.ToDateFormat("dd 'de' MMMM");
					i.markers[fechaTerminoMesDiaIndex].value = contrato.CreatedAt.AddMonths(12).ToDateFormat();
					p.markers[precioTextoIndex].value = p?.markers[precioIndex]?.value?.NumberToText();

					var doc = await _baseHtmlToPdf.CreatePdfFor<Contrato>([i, a, s, f, p]);

					return doc;
				}
			}

			throw new NotImplementedException();
		}
	}
}
