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
    
    public async Task<List<Categorias>> GetAllAsync()
    {
        return (await _dbContext.Connection.GetAllAsync<Categorias>()).ToList();
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