using Core.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Base.Interfaces
{
	public interface ISeederFacade<TBaseEntity> where TBaseEntity : BaseEntity
	{
		public void Seed();

	}
}
