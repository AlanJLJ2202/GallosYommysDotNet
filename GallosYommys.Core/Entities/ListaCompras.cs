namespace GallosYommys.Core.Entities;

public class ListaCompras : EntityBase
{
    public int user_id { get; set; }
    
    public string nombre { get; set; }
    
    public string fecha { get; set; }
    
    public ListaCompras()
    {
        
    }
}