using GallosYommys.WebAPI.Dto;

namespace GallosYommys.WebAPI.Services.Interfaces;

public interface IBalancesService
{
    Task<bool> BalancesExist(int id);
    
    Task<BalancesDto> SaveAsync(BalancesDto balances);
    
    //Metodo para Actualizar los productos
    
    Task<BalancesDto> UpdateAsync(BalancesDto balances);
    
    
    //Metodo para retornar una lista de productos
    Task<List<BalancesDto>> GetAllAsync();
    
    //Metodo para retornar el id de los productos que se borrará
    Task<bool> DeleteAsync(int id);
    
    //Metodo para obtener un producto
    Task<BalancesDto?> GetById(int id);
}