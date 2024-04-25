using GallosYommys.WebAPI.Dto;

namespace GallosYommys.WebAPI.Services.Interfaces;

public interface IUsersService
{

    Task<UsersDto> Login(UsersDto users);
    
    Task<bool> UsersExist(int id);
    
    Task<UsersDto> SaveAsync(UsersDto users);
    
    //Metodo para Actualizar los productos
    Task<UsersDto> UpdateAsync(UsersDto users);
    
    //Metodo para retornar una lista de productos
    Task<List<UsersDto>> GetAllAsync();
    
    //Metodo para retornar el id de los productos que se borrará
    Task<bool> DeleteAsync(int id);
    
    //Metodo para obtener un producto por id
    Task<UsersDto?> GetById(int id);
}