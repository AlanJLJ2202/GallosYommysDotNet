using Dapper.Contrib.Extensions;
using GallosYommys.WebAPI.DataAccess;
using GallosYommys.WebAPI.DataAccess.Interfaces;
using GallosYommys.WebAPI.Repositories;
using GallosYommys.WebAPI.Repositories.Interfaces;
using GallosYommys.WebAPI.Services;
using GallosYommys.WebAPI.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IDbContext, DbContext>();


// Agregar la configuración del dominio
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
var domain = builder.Configuration["AppSettings:Domain"];
builder.Services.AddSingleton(domain); // Agrega el dominio como servicio singleton

var app = builder.Build();


SqlMapperExtensions.TableNameMapper = entityType =>
{
    var name = entityType.ToString();
    if (name.Contains("GallosYommys.Core.Entities."))
        name = name.Replace("GallosYommys.Core.Entities.", "");
    var letters = name.ToCharArray();
    letters[0] = char.ToUpper(letters[0]);
    return new string(letters);
};

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();