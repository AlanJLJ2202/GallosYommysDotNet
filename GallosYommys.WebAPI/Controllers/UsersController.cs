using GallosYommys.Core.Entities;
using GallosYommys.Core.Http;
using GallosYommys.WebAPI.Dto;
using GallosYommys.WebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GallosYommys.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    
        private readonly IUsersService _usersService;
        
        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }
        
        
        //login
        
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<Response<UsersDto>>> Login([FromBody] UsersDto usersDto)
        {
            var response = new Response<UsersDto>();
            response.data = await _usersService.Login(usersDto);
            
            if (response.data == null)
            {
                response.Errors.Add("User not found");
                return NotFound(response);
            }
            
            return Ok(response);
        }
        
        
        [HttpGet]
        public async Task<ActionResult<Response<List<Users>>>> GetAll()
        {
            var response = new Response<List<UsersDto>>();
            response.data = await _usersService.GetAllAsync();
            
            return Ok(response);
        }
        
        
        [HttpPost]
        public async Task<ActionResult<Response<UsersDto>>> Post([FromBody] UsersDto usersDto)
        {
            var response = new Response<UsersDto>();
            response.data = await _usersService.SaveAsync(usersDto);
    
            return Created($"/api/[controller]/{response.data.id}", response); 
        }
        
        
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Response<UsersDto>>> GetByID(int id)
        {
            var response = new Response<UsersDto>();
            
            if (!await _usersService.UsersExist(id))
            {
                response.Errors.Add("Users not found");
                return NotFound(response);
            }
            
            var product = await _usersService.GetById(id);
            
            response.data = product;
            response.Message = "Users found";
            
            return Ok(response);
        }
        
        
        [HttpPut]
        public async Task<ActionResult<Response<UsersDto>>> Put([FromBody] UsersDto usersDto)
        {
            var response = new Response<UsersDto>();
            
            if (!await _usersService.UsersExist(usersDto.id))
            {
                response.Errors.Add("Users not found");
                return NotFound(response);
            }
            
            response.data = await _usersService.UpdateAsync(usersDto);
    
            return Ok(response);
        }
        
        
        [HttpDelete]
        public async Task<ActionResult<Response<UsersDto>>> Delete(int id)
        {
            var response = new Response<UsersDto>();
            
            if (!await _usersService.UsersExist(id))
            {
                response.Errors.Add("Users not found");
                return NotFound(response);
            }
            
            await _usersService.DeleteAsync(id);
            
            return Ok(response);
        }
        
        
    
}