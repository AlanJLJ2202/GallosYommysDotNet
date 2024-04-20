using Dapper.Contrib.Extensions;
using GallosYommys.Core.Entities;
using GallosYommys.WebAPI.DataAccess.Interfaces;
using GallosYommys.WebAPI.Repositories.Interfaces;

namespace GallosYommys.WebAPI.Repositories;

public class ProductRepository : IProductRepository
{
    
    private readonly IDbContext _dbContext;
    private readonly List<Products> _products;
    
    public ProductRepository(IDbContext context)
    {
        _dbContext = context;
    }
    
    public async Task<Products> SaveAsync(Products product)
    {
        
        await _dbContext.Connection.InsertAsync(product);
        
        /*string sql = $"INSERT INTO Products (Name, Description) VALUES ('{product.Name}', '{product.Description}')";
    
        await _dbContext.Connection.OpenAsync();
    
        using (var command = _dbContext.Connection.CreateCommand())
        {
            command.CommandText = sql;
        
            await command.ExecuteNonQueryAsync();
        }
    
        _dbContext.Connection.Close();*/
    
        return product;
    }
    
    
    public async Task<Products> UpdateAsync(Products product)
    {
        await _dbContext.Connection.UpdateAsync(product);
        
        /*string sql = $"UPDATE Products SET Name = '{product.Name}', Description = '{product.Description}' WHERE Id = {product.id}";
    
        await _dbContext.Connection.OpenAsync();
    
        using (var command = _dbContext.Connection.CreateCommand())
        {
            command.CommandText = sql;
        
            await command.ExecuteNonQueryAsync();
        }
    
        _dbContext.Connection.Close();*/
    
        return product;
    }
    
    
    public async Task<List<Products>> GetAllAsync()
    {
        return (await _dbContext.Connection.GetAllAsync<Products>()).ToList();
    }
    
    
    public async Task<Products?> GetById(int id)
    {
        return await _dbContext.Connection.GetAsync<Products>(id);
    }
    
    
    public async Task<bool> DeleteAsync(int id)
    {
        try
        {
            var product = await GetById(id);
        
            if (product == null)
                return false;
        
            product.IsDeleted = true;
        
            await _dbContext.Connection.UpdateAsync(product);
        
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ocurrió un error al intentar eliminar el producto: {ex.Message}");
            return false;
        }
    }
    
    public ProductRepository()
    {
        _products = new List<Products>();
    }
}