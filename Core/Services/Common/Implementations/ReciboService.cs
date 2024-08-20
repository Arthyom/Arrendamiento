
using Core.DTOs;
using Core.Helpers;
using Core.Models.Entities;
using Core.Services.Base.Implementations;
using Core.Services.Base.Interfaces;
using Core.Services.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Common.Implementations
{
	public class ReciboService : ServiceDocBase<Recibo>, IReciboService
	{
		public ReciboService(IRepoBase<Recibo> repoGenerico, IBaseHtmlToPdf doc) : base(repoGenerico, doc)
		{
		}

		public new async Task<Recibo?> CreateAsync(Recibo toCreate)
		{
			Propiedad? propiedad = await _repoGenerico.createInstance<Propiedad>()
				.GetByIdAsync(toCreate.PropiedadId);

			DateTime now = DateTime.Now;

			if (propiedad != null)
			{
				toCreate.Identificador = Guid.NewGuid().ToString();
				toCreate.Concepto = $"RECIBO DE PAGO POR CONCEPTO: RENTA {now.ToDateFormat("MMMM 'de' yyyy").ToUpper()}";
				toCreate.Total = propiedad.Precio;
				
				return await _repoGenerico.CreateAsync(toCreate);
			}

			throw new Exception();
		}


		public new async Task<DocumentResponseDto> CreateDocument(int id)
		{
			var recibo = await _repoGenerico.GetByIdAsync(id);

			if (recibo != null)
			{
				var r = await GetMarkersAsync<Recibo>(id);
				var a = await GetMarkersAsync<Arrendador>(recibo.ArrendadorId);
				var s = await GetMarkersAsync<Arrendatario>(recibo.ArrendatarioId);
				var p = await GetMarkersAsync<Propiedad>(recibo.PropiedadId);

				if (r == null || a == null || s == null || p == null)
					throw new NotImplementedException();


				if (r.markers != null && a.markers != null && s.markers != null && p.markers != null)
				{
					int fechaEmisionIndex = r.markers.FindIndex(x => x.name == "ReciboFechaHoraEmision");
					int precioTextoIndex = r.markers.FindIndex(x => x.name == "ReciboTotalPrecioTexto");
					int precioTotalIndex = r.markers.FindIndex(x => x.name == "ReciboTotal");


					r.markers[fechaEmisionIndex].value = recibo.CreatedAt.ToDateFormat("dd 'de' MMMM 'del' yyyy 'a las' HH:mm");
					r.markers[precioTextoIndex].value = r?.markers[precioTotalIndex]?.value?.NumberToText();


					var doc = await _baseHtmlToPdf.CreatePdfFor<Recibo>([r, a, s, p]);

					return doc;
				}
			}

			throw new NotImplementedException();
		}


	}
}
