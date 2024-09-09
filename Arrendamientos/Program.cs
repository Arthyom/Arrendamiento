using Core.Models.Context;
using Core.Models.Entities;
using Core.Services.Base.Implementations;
using Core.Services.Base.Interfaces;
using Core.Services.Common.Implementations;
using Core.Services.Common.Interfaces;
using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.ResolveConflictingActions(s => s.First());
});



builder.Services.AddScoped(typeof(IServiceBase<>), typeof(ServiceBase<>));
builder.Services.AddScoped(typeof(IServiceDocBase<>), typeof(ServiceDocBase<>));
builder.Services.AddScoped(typeof(ISeederFacade<>), typeof(SeederFacade<>));
builder.Services.AddScoped(typeof(IRepoBase<>), typeof(RepoBase<>));

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


using (var scope = app.Services.CreateScope())
{
    Type[] types = [
        typeof(Propiedad),
        typeof(Arrendador),
        typeof(Arrendatario),
        typeof(Contrato),
        typeof(Fiador)
    ];

    var dbContext = scope.ServiceProvider.GetRequiredService<ArrendamientoContext>();

    dbContext.Database.Migrate();

    foreach (var type in types)
    {
        var specific = typeof(SeederFacade<>).MakeGenericType(type);
        var target = Activator.CreateInstance(specific, dbContext);

        var mInfo = specific.GetMethod("Seed");

        if (mInfo == null)
            throw new Exception("Error seeding data");
        else
            mInfo.Invoke(target, null);
    }
}

app.UseAuthorization();

app.MapControllers();

app.Run();
