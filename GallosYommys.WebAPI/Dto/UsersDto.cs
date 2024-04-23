using GallosYommys.Core.Entities;

namespace GallosYommys.WebAPI.Dto;

public class UsersDto : DtoBase
{
 
    public string name { get; set; }
    
    public string email { get; set; }
    
    public string password { get; set; }
    
    public UsersDto()
    {
        
    }
    
    public UsersDto(Users users)
    {
        name = users.name;
        email = users.email;
        password = users.password;
    }
}