using GallosYommys.Core.Entities;

namespace GallosYommys.WebAPI.Repositories.Interfaces;

public interface IBalancesRepository
{
    
    Task<Balances> SaveAsync(Balances balances);
    
    //Metodo para Actualizar los productos
    Task<Balances> UpdateAsync(Balances balances);
    
    //Metodo para retornar una lista de productos
    Task<List<Balances>> GetAllAsync();
    
    //Metodo para retornar el id de los productos que se borrará
    Task<bool> DeleteAsync(int id);
    
    //Metodo para obtener un producto
    Task<Balances?> GetById(int id);
    
}