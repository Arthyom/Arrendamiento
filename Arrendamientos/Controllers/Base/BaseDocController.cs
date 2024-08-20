using Core.Models.Entities;
using Core.Services.Base.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Arrendamiento.Controllers.Base
{
	public class BaseDocController<TEntity, TBaseDocService> : BaseController<TEntity, TBaseDocService>
		where TEntity : BaseEntity
		where TBaseDocService : IServiceDocBase<TEntity>
	{
		protected readonly IServiceDocBase<TEntity> _serviceBaseDoc;

		public BaseDocController
			(IServiceDocBase<TEntity> serviceBaseDoc)
			: base(serviceBaseDoc)
		{
			_serviceBaseDoc = serviceBaseDoc;

		}

		[HttpGet]
		[Route("Documento/{id}")]
		public async Task<IActionResult> Documento([FromRoute] int id)
		{
			try
			{
				var response = await _serviceBaseDoc.CreateDocument(id);
				if (response != null)
					return File(response.Data, response.ContentType, response.NameAndExtension);

				return BadRequest();
			}
			catch (Exception e)
			{
				return Problem(e.Message);
			}
		}
	}
}
