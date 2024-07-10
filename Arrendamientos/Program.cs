using Core.Models.Context;
using Core.Services.Base.Implementations;
using Core.Services.Base.Interfaces;
using Core.Services.Common.Implementations;
using Core.Services.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.ResolveConflictingActions( s => s.First() );
});



builder.Services.AddScoped( typeof(IServiceBase<>), typeof(ServiceBase<>) );
builder.Services.AddScoped( typeof(IRepoBase<>), typeof(RepoBase<>) );

builder.Services.AddScoped<IFiadorService, FiadorService>();

var cn = builder.Configuration.GetConnectionString("Arrendamiento");

builder.Services.AddDbContext<ArrendamientoContext>(opt => opt.UseMySql(cn, ServerVersion.AutoDetect(cn)));

var app = builder.Build();
    app.UseSwagger();
    app.UseSwaggerUI();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
