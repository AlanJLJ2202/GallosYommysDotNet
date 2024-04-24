using GallosYommys.Core.Entities;

namespace GallosYommys.WebAPI.Repositories.Interfaces;

public interface ITransaccionesRepository
{
    
    Task<Transacciones> SaveAsync(Transacciones transacciones);
    
    //Metodo para Actualizar los productos
    Task<Transacciones> UpdateAsync(Transacciones transacciones);
    
    //Metodo para retornar una lista de productos
    Task<List<Transacciones>> GetAllAsync();
    
    //Metodo para retornar el id de los productos que se borrará
    Task<bool> DeleteAsync(int id);
    
    //Metodo para obtener un producto
    Task<Transacciones?> GetById(int id);
}