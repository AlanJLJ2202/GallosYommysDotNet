using GallosYommys.WebAPI.Dto;

namespace GallosYommys.WebAPI.Services.Interfaces;

public interface ICategoriasService
{
    Task<bool> CategoriasExist(int id);
    
    Task<CategoriasDto> SaveAsync(CategoriasDto categorias);
    
    //Metodo para Actualizar los productos
    Task<CategoriasDto> UpdateAsync(CategoriasDto categorias);
    
    //Metodo para retornar una lista de productos
    Task<List<CategoriasDto>> GetAllAsync();
    
    //Metodo para retornar el id de los productos que se borrará
    Task<bool> DeleteAsync(int id);
    
    //Metodo para obtener un producto por id
    Task<CategoriasDto?> GetById(int id);
}