using GallosYommys.WebAPI.Dto;

namespace GallosYommys.WebAPI.Services.Interfaces;

public interface IListaComprasService
{
    
    Task<bool> ListaComprasExist(int id);
    
    Task<ListaComprasDto> SaveAsync(ListaComprasDto listaCompras);
    
    //Metodo para Actualizar los productos
    Task<ListaComprasDto> UpdateAsync(ListaComprasDto listaCompras);
    
    //Metodo para retornar una lista de productos
    Task<List<ListaComprasDto>> GetAllAsync();
    
    //Metodo para retornar el id de los productos que se borrará
    Task<bool> DeleteAsync(int id);
    
    //Metodo para obtener un producto por id
    Task<ListaComprasDto?> GetById(int id);
    
}