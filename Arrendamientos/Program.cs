using Core.Models.Context;
using Core.Services.Base.Implementations;
using Core.Services.Base.Interfaces;
using Core.Services.Common.Implementations;
using Core.Services.Common.Interfaces;
using DinkToPdf;
using DinkToPdf.Contracts;
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
builder.Services.AddScoped( typeof(IServiceDocBase<>), typeof(ServiceDocBase<>) );
builder.Services.AddScoped( typeof(IRepoBase<>), typeof(RepoBase<>) );

builder.Services.AddScoped<IFiadorService, FiadorService>();
builder.Services.AddScoped<IArrendadorService, ArrendadorService>();
builder.Services.AddScoped<IArrendatarioService, ArrendatarioService>();
builder.Services.AddScoped<IContratoService, ContratoService>();
builder.Services.AddScoped<IReciboService, ReciboService>();
builder.Services.AddScoped<IPropiedadService, PropiedadService>();

builder.Services.AddScoped<IBaseHtmlToPdf, BaseHtmlToPdf>();




builder.Services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));

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
