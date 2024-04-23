using GallosYommys.Core.Entities;

namespace GallosYommys.WebAPI.Dto;

public class ListaComprasDto : DtoBase
{
    
    public int user_id { get; set; }
    
    public string nombre { get; set; }
    
    public string fecha { get; set; }
    
    public ListaComprasDto()
    {
        
    }
    
    public ListaComprasDto(ListaCompras listaCompras)
    {
        id = listaCompras.id;
        user_id = listaCompras.user_id;
        nombre = listaCompras.nombre;
        fecha = listaCompras.fecha;
    }
    
}