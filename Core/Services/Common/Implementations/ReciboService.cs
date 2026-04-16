
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
            
            Interior? interior = await _repoGenerico.createInstance<Interior>()
                .GetByIdAsync(toCreate.InteriorId);

            if (propiedad != null && interior != null)
            {
                  DateTime fechaPago = toCreate.FechaPago.HasValue ? toCreate.FechaPago.Value : DateTime.Now;
                string concepto = toCreate.Concepto;
                toCreate.Identificador = Guid.NewGuid().ToString();
                toCreate.Concepto = $"RECIBO DE PAGO POR CONCEPTO DE RENTA {fechaPago.ToDateFormat("MMMM 'de' yyyy").ToUpper()} - [P] - [I]"
                .Replace("[P]", propiedad.Direccion.ToUpper())
                .Replace("[I]", interior.Etiqueta?.ToUpper());
                toCreate.Total = interior.Precio;
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
                
                if (recibo.PropiedadId == 0 && p != null)
                {
                    if(p.markers != null)
                    {
                        p.markers[0].value = "";

                        p.markers[1].value = recibo.Total.ToString("0.00");
                        
                        p.markers[2].value = recibo.Concepto;

                        p.markers[3].value = recibo.Total.ToString("0.00");

                        p.markers[4].value = recibo.Concepto;
                    }
                }
                else
                {
                    if(p == null)
                        throw new Exception("Propiedad no encontrada");

                    if(p.markers != null)
                    {
                        p.markers[3].value = recibo.Total.ToString("0.00");
                    }
                }


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

                    var arrendatarioNombre = s.markers.Find(x => x.name == "ArrendatarioNombre");
                    var propiedadDireccion = p.markers.Find(x => x.name == "PropiedadDireccion");

                    await _repoGenerico.createInstance<ReImpresion>().CreateAsync(new ReImpresion() { ReciboId = recibo.Id } );

                    if (arrendatarioNombre != null && propiedadDireccion != null)
                        doc.NameAndExtension = $"{arrendatarioNombre.value} {propiedadDireccion.value} {recibo.Concepto}.pdf";

                    return doc;
                }
            }

            throw new NotImplementedException();
        }

        public async Task<Recibo> CreateSingle(Recibo toCreate)
        {
            DateTime fechaPago = toCreate.FechaPago.HasValue ? toCreate.FechaPago.Value : DateTime.Now;
            toCreate.Identificador = Guid.NewGuid().ToString();
            toCreate.FechaPago = fechaPago;
            Recibo? response =  await _repoGenerico.CreateAsync(toCreate);

            if (response != null)
                return response;
            
            throw new Exception();
        }
    }
}
