using System;
using Core.Enums;
using Core.Models.Entities;
using Core.Services.Base.Interfaces;

namespace Core.Services.Common.Interfaces;

public interface IDeployService : IServiceBase<Deploy>
{
    public  Task<Deploy> Deploy(TypeDeployEnum target);
}
