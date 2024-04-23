namespace GallosYommys.Core.Entities;

public class ListaProductos : EntityBase
{
    
    public int lista_compra_id { get; set; }
    
    public int producto_id { get; set; }
    
    public int cantidad { get; set; }
    
    public decimal precio_compra { get; set; }
    
    public string producto_nombre { get; set; }
    
    public string producto_descripcion { get; set; }
    
    public ListaProductos()
    {
        
    }
}