namespace GallosYommys.Core.Entities;

public class Users : EntityBase
{
    public string name { get; set; }
    
    public string email { get; set; }
    
    public string password { get; set; }
    
    public Users()
    {
        
    }
}