using GallosYommys.Core.Entities;

namespace GallosYommys.WebAPI.Repositories.Interfaces;

public interface IListaProductosRepository
{
    Task<ListaProductos> SaveAsync(ListaProductos listaProductos);
    
    //Metodo para Actualizar los productos
    Task<ListaProductos> UpdateAsync(ListaProductos listaProductos);
    
    //Metodo para retornar una lista de productos
    Task<List<ListaProductos>> GetAllAsync(int lista_id);
    
    //Metodo para retornar el id de los productos que se borrará
    Task<bool> DeleteAsync(int id);
    
    //Metodo para obtener un producto por id
    Task<ListaProductos?> GetById(int id);
}