using GallosYommys.Core.Entities;

namespace GallosYommys.WebAPI.Dto;

public class ListaProductosDto : DtoBase
{
    public int lista_compra_id { get; set; }
    
    public int producto_id { get; set; }
    
    public int cantidad { get; set; }
    
    public decimal precio_compra { get; set; }
    
    public string producto_nombre { get; set; }
    
    public string producto_descripcion { get; set; }
    
    public ListaProductosDto()
    {
        
    }
    public ListaProductosDto(ListaProductos listaProductos)
    {
        id = listaProductos.id;
        lista_compra_id = listaProductos.lista_compra_id;
        producto_id = listaProductos.producto_id;
        cantidad = listaProductos.cantidad;
        precio_compra = listaProductos.precio_compra;
        producto_nombre = listaProductos.producto_nombre;
        producto_descripcion = listaProductos.producto_descripcion;
    }
}