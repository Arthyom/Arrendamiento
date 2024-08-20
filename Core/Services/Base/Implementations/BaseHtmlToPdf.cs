using Core.DTOs;
using Core.Helpers;
using Core.Markers;
using Core.Models.Entities;
using Core.Services.Base.Interfaces;
using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Base.Implementations
{
	public class BaseHtmlToPdf : IBaseHtmlToPdf
	{
		private readonly IConverter _converter;

		public BaseHtmlToPdf(IConverter converter)
		{
			_converter = converter;
		}

		private Task InsertImage()
		{
			return Task.CompletedTask;
		}

		private async Task<string> ReplaceMarkers<TDocType>(MarkerDtoCollection? markerCollection, string documentContent)
		{
			markerCollection?.markers?.ForEach(marker =>
			{
				documentContent = documentContent.Replace(marker.key, marker.value);
			});

			return await Task.FromResult(documentContent);
		}

		private string MapDocumentType<TDocType>()
		{
			string? recivedType = typeof(TDocType).Name;

			string? contratoType = typeof(Contrato).Name;
			string? reciboType = typeof(Recibo).Name;

			return contratoType != null ? contratoType : "";

			//switch (reciboType)
			//{
			//    case "Recibo":

			//        break;

			//    default:
			//    case "Contrato":
			//        break;
			//}
		}

		private async Task<string> GetHtmlContent<TDocType>()
		{
			string documentType = typeof(TDocType).Name;
			string documentName = $"{documentType}.html";
			string stringContent;
			var assembly = Assembly.GetExecutingAssembly();
			var resourceName = "Core.Templates.Html." + documentName;

			using (Stream? stream = assembly.GetManifestResourceStream(resourceName))
			{
				if (stream != null)
				{
					using (StreamReader reader = new StreamReader(stream))
					{
						stringContent = reader.ReadToEnd();
					}
				}
				else
					throw new Exception("no se puete creare");
			}

			return await Task.FromResult(stringContent);
		}

		private HtmlToPdfDocument CreateDocument<TDocType>()
		{
			return new HtmlToPdfDocument()
			{
				GlobalSettings = new GlobalSettings()
				{
					ColorMode = ColorMode.Color,
					Orientation = Orientation.Portrait,
					PaperSize = PaperKind.A4,
					Margins = new MarginSettings()
					{ Top = 20, Bottom = 20, Left = 20, Right = 20 }
				},

				Objects = { new ObjectSettings()
					{
						PagesCount = true,
						WebSettings = { DefaultEncoding = "utf-8" },
					}
				}
			};
		}

		public async Task<DocumentResponseDto> CreatePdfFor<TDocType>(params MarkerDtoCollection?[] markersCollection)
		{
			string contentType = "application/pdf";
			var document = CreateDocument<TDocType>();
			string documentContent = await GetHtmlContent<TDocType>();

			foreach (var markerCollection in markersCollection)
			{
				documentContent = await ReplaceMarkers<TDocType>(markerCollection, documentContent);
			}

			document.Objects[0].HtmlContent = documentContent;

			var createdDocument = new DocumentResponseDto()
			{
				Data = _converter.Convert(document),
				ContentType = contentType,
				NameAndExtension = "ejemplo.pdf"
			};

			return createdDocument;
		}
	}
}
