namespace GallosYommys.Core.Entities;

public class Transacciones : EntityBase
{
    public int user_id { get; set; }
    
    public double monto { get; set; }
    
    public string tipo { get; set; }
    
    public string descripcion { get; set; }
    
    public DateTime fecha { get; set; }
    
    public Transacciones()
    {
    }
}