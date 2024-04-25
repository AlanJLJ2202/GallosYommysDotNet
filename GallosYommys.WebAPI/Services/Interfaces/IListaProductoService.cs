using GallosYommys.WebAPI.Dto;

namespace GallosYommys.WebAPI.Services.Interfaces;

public interface IListaProductosService
{
    
    Task<bool> ListaProductosExist(int id);
    
    Task<ListaProductosDto> SaveAsync(ListaProductosDto listaProducto);
    
    //Metodo para Actualizar los productos
    Task<ListaProductosDto> UpdateAsync(ListaProductosDto listaProducto);
    
    //Metodo para retornar una lista de productos
    Task<List<ListaProductosDto>> GetAllAsync(int lista_id);
    
    //Metodo para retornar el id de los productos que se borrará
    Task<bool> DeleteAsync(int id);
    
    //Metodo para obtener un producto por id
    Task<ListaProductosDto?> GetById(int id);
    
}