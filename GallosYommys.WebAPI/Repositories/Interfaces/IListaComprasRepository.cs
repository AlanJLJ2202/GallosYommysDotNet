using GallosYommys.Core.Entities;

namespace GallosYommys.WebAPI.Repositories.Interfaces;

public interface IListaComprasRepository
{
    Task<ListaCompras> SaveAsync(ListaCompras listaCompras);
    
    //Metodo para Actualizar los productos
    Task<ListaCompras> UpdateAsync(ListaCompras listaCompras);
    
    //Metodo para retornar una lista de productos
    Task<List<ListaCompras>> GetAllAsync(int user_id);
    
    //Metodo para retornar el id de los productos que se borrará
    Task<bool> DeleteAsync(int id);
    
    //Metodo para obtener un producto por id
    Task<ListaCompras?> GetById(int id);
}