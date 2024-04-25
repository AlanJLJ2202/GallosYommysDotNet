using GallosYommys.WebAPI.Dto;

namespace GallosYommys.WebAPI.Services.Interfaces;

public interface IProductService
{
    
    Task<bool> ProductExist(int id);
    
    Task<ProductDto> SaveAsync(ProductDto product);
    
    //Metodo para Actualizar los productos
    Task<ProductDto> UpdateAsync(ProductDto product);
    
    //Metodo para retornar una lista de productos
    Task<List<ProductDto>> GetAllAsync(int user_id);
    
    //Metodo para retornar el id de los productos que se borrará
    Task<bool> DeleteAsync(int id);
    
    //Metodo para obtener un producto por id
    Task<ProductDto?> GetById(int id);
}