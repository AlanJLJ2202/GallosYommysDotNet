using Dapper;
using Dapper.Contrib.Extensions;
using GallosYommys.Core.Entities;
using GallosYommys.WebAPI.DataAccess.Interfaces;
using GallosYommys.WebAPI.Repositories.Interfaces;

namespace GallosYommys.WebAPI.Repositories;

public class CategoriasRepository : ICategoriasRepository
{
    
    private readonly IDbContext _dbContext;
    private readonly List<Categorias> _categorias;

    
    public CategoriasRepository(IDbContext context)
    {
        _dbContext = context;
    }
    
    public async Task<Categorias> SaveAsync(Categorias categorias)
    {
        await _dbContext.Connection.InsertAsync(categorias);
        return categorias;
    }
    
    public async Task<Categorias> UpdateAsync(Categorias categorias)
    {
        await _dbContext.Connection.UpdateAsync(categorias);
        return categorias;
    }
    
    public async Task<List<Categorias>> GetAllAsync(int user_id)
    {
        //where IsDeleted = false
        const string query = "SELECT * FROM Categorias WHERE IsDeleted = 0 AND user_id = @user_id ORDER BY CreatedDate DESC";
        var categorias = await _dbContext.Connection.QueryAsync<Categorias>(query, new { user_id });
        return categorias.ToList();
    }
    
    public async Task<bool> DeleteAsync(int id)
    {
        try
        {

            var categorias = await GetById(id);

            if (categorias == null)
                return false;

            categorias.IsDeleted = true;
        
            await _dbContext.Connection.UpdateAsync(categorias);

            return true;
            
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    public async Task<Categorias?> GetById(int id)
    {
        return await _dbContext.Connection.GetAsync<Categorias>(id);
    }
    
}