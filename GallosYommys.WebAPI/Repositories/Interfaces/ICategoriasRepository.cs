using GallosYommys.Core.Entities;

namespace GallosYommys.WebAPI.Repositories.Interfaces;

public interface ICategoriasRepository
{
    Task<Categorias> SaveAsync(Categorias categorias);
    
    //Metodo para Actualizar los productos
    Task<Categorias> UpdateAsync(Categorias categorias);
    
    //Metodo para retornar una lista de productos
    Task<List<Categorias>> GetAllAsync(int user_id);
    
    //Metodo para retornar el id de los productos que se borrará
    Task<bool> DeleteAsync(int id);
    
    //Metodo para obtener un producto por id
    Task<Categorias?> GetById(int id);
}