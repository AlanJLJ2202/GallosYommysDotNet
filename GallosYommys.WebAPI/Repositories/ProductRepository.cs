using Dapper;
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
    
        return product;
    }
    
    
    public async Task<Products> UpdateAsync(Products product)
    {
        await _dbContext.Connection.UpdateAsync(product);
    
        return product;
    }
    
    
    public async Task<List<Products>> GetAllAsync(int user_id)
    {
        //where IsDeleted = false
        const string query = "SELECT * FROM Products WHERE IsDeleted = 0 AND user_id = @user_id ORDER BY CreatedDate DESC";
        var products = await _dbContext.Connection.QueryAsync<Products>(query, new { user_id });
        return products.ToList();
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