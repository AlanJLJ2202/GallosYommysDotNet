using GallosYommys.WebAPI.Dto;

namespace GallosYommys.WebAPI.Services.Interfaces;

public interface ITransaccionesService
{
    Task<bool> TransaccionesExist(int id);
    
    Task<TransaccionesDto> SaveAsync(TransaccionesDto transacciones);
    
    //Metodo para Actualizar los productos
    
    Task<TransaccionesDto> UpdateAsync(TransaccionesDto transacciones);
    
    
    //Metodo para retornar una lista de productos
    Task<List<TransaccionesDto>> GetAllAsync(int user_id);
    
    //Metodo para retornar el id de los productos que se borrará
    Task<bool> DeleteAsync(int id);
    
    //Metodo para obtener un producto
    Task<TransaccionesDto?> GetById(int id);
}