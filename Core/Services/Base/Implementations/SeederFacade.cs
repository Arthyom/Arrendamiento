using Core.DTOs.Base;
using Core.Helpers;
using Core.Models.Context;
using Core.Models.Entities;
using Core.Services.Base.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Core.Services.Base.Implementations
{
	public class SeederFacade<TBaseEntity> : ISeederFacade<TBaseEntity> where TBaseEntity : BaseEntity
	{
		private readonly ArrendamientoContext _context;

		public SeederFacade(ArrendamientoContext context)
		{
			_context = context;
		}

		public void Seed()
		{
			string entityName = typeof(TBaseEntity).Name;
			string documentName = $"{entityName}Data.json";
			string stringContent;
			var assembly = Assembly.GetExecutingAssembly();
			var resourceName = "Core.Seeder.Data." + documentName;

			using (Stream? stream = assembly.GetManifestResourceStream(resourceName))
			{
				if (stream != null)
				{
					using (StreamReader reader = new StreamReader(stream))
					{
						stringContent = reader.ReadToEnd().CorrectSeederBoolen();

						var seederData = JsonConvert.DeserializeObject<BaseSeederDto<TBaseEntity>>(stringContent);

						if (seederData != null)
							if (seederData.Data != null)
							{
								if (seederData.Data.Any())
								{
									var entity = _context.Set<TBaseEntity>();

									seederData.Data.ForEach(x =>
									{
										if (!entity.Where(z => z.Id == x.Id).Any())
										{
											_context.Set<TBaseEntity>().Add(x);
											_context.SaveChanges();
										}
									});
								}
							}
					}
				}
				else
					throw new Exception("Cannot insert seeder data");
			}
		}
	}
}
