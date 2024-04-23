using Dapper.Contrib.Extensions;
using GallosYommys.Core.Entities;
using GallosYommys.WebAPI.DataAccess.Interfaces;
using GallosYommys.WebAPI.Repositories.Interfaces;

namespace GallosYommys.WebAPI.Repositories;

public class UsersRepository : IUsersRepository
{
    
    private readonly IDbContext _dbContext;
    private readonly List<Users> _users;
    
    public UsersRepository(IDbContext context)
    {
        _dbContext = context;
    }
    
    public async Task<Users> SaveAsync(Users users)
    {
        await _dbContext.Connection.InsertAsync(users);
        return users;
    }
    
    public async Task<Users> UpdateAsync(Users users)
    {
        await _dbContext.Connection.UpdateAsync(users);
        return users;
    }
    
    public async Task<List<Users>> GetAllAsync()
    {
        return (await _dbContext.Connection.GetAllAsync<Users>()).ToList();
    }
    
    
    
    public async Task<bool> DeleteAsync(int id)
    {
        try
        {

            var users = await GetById(id);

            if (users == null)
                return false;

            users.IsDeleted = true;
        
            await _dbContext.Connection.UpdateAsync(users);

            return true;
            
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    public async Task<Users?> GetById(int id)
    {
        return await _dbContext.Connection.GetAsync<Users>(id);
    }
    
}