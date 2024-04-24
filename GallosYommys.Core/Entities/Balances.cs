namespace GallosYommys.Core.Entities;

public class Balances : EntityBase
{
    public int user_id { get; set; }
    
    public double saldo { get; set; }
    
    public Balances()
    {
        
    }
}