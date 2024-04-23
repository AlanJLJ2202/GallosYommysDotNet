using GallosYommys.Core.Entities;

namespace GallosYommys.WebAPI.Repositories.Interfaces;

public interface IUsersRepository
{
 
    Task<Users> SaveAsync(Users users);
    
    //Metodo para Actualizar los productos
    Task<Users> UpdateAsync(Users users);
    
    //Metodo para retornar una lista de productos
    Task<List<Users>> GetAllAsync();
    
    //Metodo para retornar el id de los productos que se borrará
    Task<bool> DeleteAsync(int id);
    
    //Metodo para obtener un producto por id
    Task<Users?> GetById(int id);
    
}