using Dapper;
using Dapper.Contrib.Extensions;
using GallosYommys.Core.Entities;
using GallosYommys.WebAPI.DataAccess.Interfaces;
using GallosYommys.WebAPI.Repositories.Interfaces;

namespace GallosYommys.WebAPI.Repositories;

public class BalancesRepository : IBalancesRepository
{
    
    private readonly IDbContext _dbContext;
    public BalancesRepository(IDbContext context)
    {
        _dbContext = context;
    }
    
    public async Task<Balances> SaveAsync(Balances balances)
    {
        await _dbContext.Connection.InsertAsync(balances);
        return balances;
    }
    
    public async Task<Balances> UpdateAsync(Balances balances)
    {
        await _dbContext.Connection.UpdateAsync(balances);
        return balances;
    }
    
    public async Task<List<Balances>> GetAllAsync()
    {
        return (await _dbContext.Connection.GetAllAsync<Balances>()).ToList();
    }
    
    public async Task<bool> DeleteAsync(int id)
    {
        try
        {
            var balances = await GetById(id);

            if (balances == null)
                return false;

            balances.IsDeleted = true;
        
            await _dbContext.Connection.UpdateAsync(balances);

            return true;
            
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    public async Task<Balances?> GetById(int id)
    {
        return await _dbContext.Connection.GetAsync<Balances>(id);
    }
    
    public async Task<Balances?> GetByUserId(int userId)
    {
        return await _dbContext.Connection.QueryFirstOrDefaultAsync<Balances>(
            "SELECT * FROM Balances WHERE user_id = @userId AND IsDeleted = 0 ORDER BY CreatedDate DESC LIMIT 1", 
            new { userId });
    }
    
}