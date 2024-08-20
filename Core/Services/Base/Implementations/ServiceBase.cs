using Core.DTOs;
using Core.Models.Entities;
using Core.Services.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Core.Services.Base.Implementations
{
	public class ServiceBase<TBaseEntity> : IServiceBase<TBaseEntity> where TBaseEntity : BaseEntity
	{
		protected IRepoBase<TBaseEntity> _repoGenerico;

		public ServiceBase(IRepoBase<TBaseEntity> repoGenerico)
		{
			_repoGenerico = repoGenerico;
		}

		public void Begin()
		{
			_repoGenerico.Begin();
		}

		public void Commit()
		{
			_repoGenerico.Commit();
		}

		public void RollBack()
		{
			_repoGenerico?.Rollback();
		}

		public async Task<IEnumerable<TBaseEntity>?> GetAllAsync()
		{
			return await _repoGenerico.GetAllAsync();
		}

		public async Task<TBaseEntity?> GetByIdAsync(int id)
		{
			return await _repoGenerico.GetByIdAsync(id);
		}

		public async Task<TBaseEntity?> CreateAsync(TBaseEntity toCreate)
		{
			return await _repoGenerico.CreateAsync(toCreate);
		}

		public async Task<TBaseEntity?> UpdateAsync(int id, TBaseEntity toUpdate)
		{
			return await _repoGenerico.UpdateAsync(id, toUpdate);
		}

		public async Task<bool> DeleteAsync(int id)
		{
			return await _repoGenerico.DeleteAsync(id);
		}

		public async Task<MarkerDtoCollection?> GetMarkersAsync<TEntity>(int id) where TEntity : BaseEntity
		{
			string entityName = typeof(TEntity).Name;

			string documentName = $"Markers{entityName}.json";

			var assembly = Assembly.GetExecutingAssembly();
			var resourceName = "Core.Markers." + documentName;

			using (Stream? stream = assembly.GetManifestResourceStream(resourceName))
			{
				if (stream != null)
				{
					using (StreamReader reader = new StreamReader(stream))
					{
						string data = reader.ReadToEnd();
						var markers = JsonSerializer.Deserialize<MarkerDtoCollection>(data);


						if (markers != null)
						{
							var matched = await _repoGenerico.createInstance<TEntity>().GetByIdAsync(id);
							foreach (var item in markers.markers)
							{
								if (matched != null)
								{
									if (!string.IsNullOrEmpty(item.property))
										item.value = ((object)matched.GetType().GetProperty(item.property)
											.GetValue(matched)).ToString();

									if (item.properties != null)
									{
										string value = "";
										foreach (var property in item.properties)
										{
											value = $"{value} " + ((object)matched.GetType().GetProperty(property.property)
												.GetValue(matched)).ToString();

										}

										item.value = value;
									}
								}
							}
						}
						return markers;
					}
				}
				else
					throw new Exception("no se puete creare");

			}
		}
	}
}
