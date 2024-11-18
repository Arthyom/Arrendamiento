using Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs.Base
{
	public class BaseSeederDto<TBaseEntity> where TBaseEntity : BaseEntity
	{
		public string? Type { get; set; }

		public string? Name { get; set; }

		public string? DataBase { get; set; }

        public string? Comment { get; set; }


		public List<TBaseEntity>? Data { get; set; }
	}
}
