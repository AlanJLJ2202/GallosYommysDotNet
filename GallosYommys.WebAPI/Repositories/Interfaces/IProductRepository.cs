using GallosYommys.Core.Entities;

namespace GallosYommys.WebAPI.Repositories.Interfaces;

public interface IProductRepository
{
    Task<Products> SaveAsync(Products product);
    
    //Metodo para Actualizar los productos
    
    Task<Products> UpdateAsync(Products product);
    
    //Metodo para retornar una lista de productos
    
    Task<List<Products>> GetAllAsync();
    
    //Metodo para retornar el id de los productos que se borrará
    
    Task<bool> DeleteAsync(int id);
    
    //Metodo para obtener un producto por id
    
    Task<Products?> GetById(int id);

}