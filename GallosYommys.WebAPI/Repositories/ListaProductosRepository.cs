using Dapper;
using Dapper.Contrib.Extensions;
using GallosYommys.Core.Entities;
using GallosYommys.WebAPI.DataAccess.Interfaces;
using GallosYommys.WebAPI.Repositories.Interfaces;

namespace GallosYommys.WebAPI.Repositories;

public class ListaProductosRepository : IListaProductosRepository
{
    private readonly IDbContext _dbContext;
    private readonly List<ListaProductos> _listaProductos;
    
    public ListaProductosRepository(IDbContext context)
    {
        _dbContext = context;
    }
    
    public async Task<ListaProductos> SaveAsync(ListaProductos listaProductos)
    {
        await _dbContext.Connection.InsertAsync(listaProductos);
    
        return listaProductos;
    }
    
    
    public async Task<ListaProductos> UpdateAsync(ListaProductos listaProductos)
    {
        await _dbContext.Connection.UpdateAsync(listaProductos);
    
        return listaProductos;
    }
    
    public async Task<List<ListaProductos>> GetAllAsync(int lista_id)
    {
        const string query = "SELECT * FROM ListaProductos WHERE IsDeleted = 0 AND lista_compra_id = @lista_id";
        var listaProductos = await _dbContext.Connection.QueryAsync<ListaProductos>(query, new { lista_id });
        return listaProductos.ToList();
    }
    

    public async Task<ListaProductos?> GetById(int id)
    {
        return await _dbContext.Connection.GetAsync<ListaProductos>(id);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        try
        {
            var listaProductos = await GetById(id);

            if (listaProductos == null)
                return false;

            listaProductos.IsDeleted = true;
        
            await _dbContext.Connection.UpdateAsync(listaProductos);

            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}