using Dapper;
using Dapper.Contrib.Extensions;
using GallosYommys.Core.Entities;
using GallosYommys.WebAPI.DataAccess.Interfaces;
using GallosYommys.WebAPI.Repositories.Interfaces;

namespace GallosYommys.WebAPI.Repositories;

public class TransaccionesRepository : ITransaccionesRepository
{

    private readonly IDbContext _dbContext;
    private readonly List<Transacciones> _transacciones;
    
    public TransaccionesRepository(IDbContext context)
    {
        _dbContext = context;
    }

    public async Task<Transacciones> SaveAsync(Transacciones transacciones)
    {
        await _dbContext.Connection.InsertAsync(transacciones);
        return transacciones;
    }

    public async Task<Transacciones> UpdateAsync(Transacciones transacciones)
    {
        await _dbContext.Connection.UpdateAsync(transacciones);
        return transacciones;
    }
    
    public async Task<List<Transacciones>> GetAllAsync(int user_id)
    {
        //where IsDeleted = false
        const string query = "SELECT * FROM Transacciones WHERE IsDeleted = 0 AND user_id = @user_id ORDER BY CreatedDate DESC";
    
        var transacciones = await _dbContext.Connection.QueryAsync<Transacciones>(query, new { user_id });
        return transacciones.ToList();
    }


    public async Task<Transacciones?> GetById(int id)
    {
        return await _dbContext.Connection.GetAsync<Transacciones>(id);
    }
    
    
    public async Task<bool> DeleteAsync(int id)
    {
        try
        {
            var transacciones = await GetById(id);

            if (transacciones == null)
                return false;

            transacciones.IsDeleted = true;
        
            await _dbContext.Connection.UpdateAsync(transacciones);

            return true;
            
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

}