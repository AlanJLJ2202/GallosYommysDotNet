namespace GallosYommys.Core.Entities;

public class Products : EntityBase
{
    public int user_id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    
    public double precio_compra { get; set; }
    
    
    
    public Products()
    {
        
    }
}