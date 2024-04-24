using Dapper.Contrib.Extensions;
using GallosYommys.WebAPI.DataAccess;
using GallosYommys.WebAPI.DataAccess.Interfaces;
using GallosYommys.WebAPI.Repositories;
using GallosYommys.WebAPI.Repositories.Interfaces;
using GallosYommys.WebAPI.Services;
using GallosYommys.WebAPI.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IListaProductosRepository, ListaProductosRepository>();
builder.Services.AddScoped<IListaProductosService, ListaProductosService>();
builder.Services.AddScoped<IListaComprasRepository, ListaComprasRepository>();
builder.Services.AddScoped<IListaComprasService, ListaComprasService>();
builder.Services.AddScoped<ICategoriasRepository, CategoriasRepository>();
builder.Services.AddScoped<ICategoriasService, CategoriasService>();
builder.Services.AddScoped<IUsersRepository, UsersRepository>();
builder.Services.AddScoped<IUsersService, UsersService>();
builder.Services.AddScoped<ITransaccionesRepository, TransaccionesRepository>();
builder.Services.AddScoped<ITransaccionesService, TransaccionesService>();
builder.Services.AddScoped<IBalancesRepository, BalancesRepository>();
builder.Services.AddScoped<IBalancesService, BalancesService>();
builder.Services.AddScoped<IDbContext, DbContext>();


// Agregar la configuración del dominio
// builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
// var domain = builder.Configuration["AppSettings:Domain"];
// builder.Services.AddSingleton(domain);

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