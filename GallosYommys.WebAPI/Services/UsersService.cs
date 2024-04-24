using GallosYommys.Core.Entities;
using GallosYommys.Core.Http;
using GallosYommys.WebAPI.Dto;
using GallosYommys.WebAPI.Repositories.Interfaces;
using GallosYommys.WebAPI.Services.Interfaces;

namespace GallosYommys.WebAPI.Services;

public class UsersService : IUsersService
{
    private readonly IUsersRepository _usersRepository;
    
    public UsersService(IUsersRepository usersRepository)
    {
        _usersRepository = usersRepository;
    }
    
    public async Task<bool> UsersExist(int id)
    {
        var users = await _usersRepository.GetById(id);
        return (users != null);
    }
    
    
    public async Task<UsersDto> SaveAsync(UsersDto users)
    {
        var usersEntity = new Users
        {
            name = users.name,
            email = users.email,
            password = users.password,
            CreatedBy = "",
            CreatedDate = DateTime.Now,
            UpdatedBy = "",
            UpdatedDate = DateTime.Now
        };
        
        usersEntity = await _usersRepository.SaveAsync(usersEntity);
        users.id = usersEntity.id;

        return users;
    }
    
    
    public async Task<UsersDto> UpdateAsync(UsersDto users)
    {
        var response = new Response<Users>();
        var usersEntity = await _usersRepository.GetById(users.id);

        if (usersEntity == null)
            throw new Exception("users not found");
            
        usersEntity.name = users.name;
        usersEntity.email = users.email;
        usersEntity.password = users.password;
        usersEntity.UpdatedBy = "";
        usersEntity.UpdatedDate = DateTime.Now;
        
        usersEntity = await _usersRepository.UpdateAsync(usersEntity);

        return users;
    }
    
    
    public async Task<List<UsersDto>> GetAllAsync()
    {
        var users = await _usersRepository.GetAllAsync();
        return users.Select(x => new UsersDto
        {
            id = x.id,
            name = x.name
        }).ToList();
    }
    
    
    public async Task<UsersDto?> GetById(int id)
    {
        var users = await _usersRepository.GetById(id);

        if (users == null)
        {
            return null;
        }

        return new UsersDto
        {
            id = users.id,
            name = users.name,
            email = users.email
        };
    }
    
    
    public async Task<bool> DeleteAsync(int id)
    {
        return await _usersRepository.DeleteAsync(id);
    }
    
    
    
}