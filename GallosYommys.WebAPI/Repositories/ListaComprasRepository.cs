using Dapper;
using Dapper.Contrib.Extensions;
using GallosYommys.Core.Entities;
using GallosYommys.WebAPI.DataAccess.Interfaces;
using GallosYommys.WebAPI.Repositories.Interfaces;

namespace GallosYommys.WebAPI.Repositories;

public class ListaComprasRepository : IListaComprasRepository
{
    
    private readonly IDbContext _dbContext;
    private readonly List<ListaCompras> _listaCompras;
    
    public ListaComprasRepository(IDbContext context)
    {
        _dbContext = context;
    }
    
    public async Task<ListaCompras> SaveAsync(ListaCompras listaCompras)
    {
        await _dbContext.Connection.InsertAsync(listaCompras);
    
        return listaCompras;
    }
    
    
    public async Task<ListaCompras> UpdateAsync(ListaCompras listaCompras)
    {
        await _dbContext.Connection.UpdateAsync(listaCompras);
    
        return listaCompras;
    }
    
    public async Task<List<ListaCompras>> GetAllAsync(int user_id)
    {
        //where IsDeleted = false
        const string query = "SELECT * FROM ListaCompras WHERE IsDeleted = 0 AND user_id = @user_id ORDER BY CreatedDate DESC";
        var listaCompras = await _dbContext.Connection.QueryAsync<ListaCompras>(query, new { user_id });
        return listaCompras.ToList();
    }

    public async Task<ListaCompras?> GetById(int id)
    {
        return await _dbContext.Connection.GetAsync<ListaCompras>(id);
    }
    
    public async Task<bool> DeleteAsync(int id)
    {
        try
        {
            var listaCompras = await GetById(id);

            if (listaCompras == null)
                return false;

            listaCompras.IsDeleted = true;
        
            await _dbContext.Connection.UpdateAsync(listaCompras);

            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

}