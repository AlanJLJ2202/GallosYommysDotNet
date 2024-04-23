using GallosYommys.Core.Entities;
using GallosYommys.Core.Http;
using GallosYommys.WebAPI.Dto;
using GallosYommys.WebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GallosYommys.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriasController : ControllerBase
{
    
    private readonly ICategoriasService _categoriasService;
    
    public CategoriasController(ICategoriasService categoriasService)
    {
        _categoriasService = categoriasService;
    }
    
    
    [HttpGet]
    public async Task<ActionResult<Response<List<Categorias>>>> GetAll()
    {
        var response = new Response<List<CategoriasDto>>();
        response.data = await _categoriasService.GetAllAsync();
        
        return Ok(response);
    }
    
    
    [HttpPost]
    public async Task<ActionResult<Response<CategoriasDto>>> Post([FromBody] CategoriasDto categoriasDto)
    {
        var response = new Response<CategoriasDto>();
        response.data = await _categoriasService.SaveAsync(categoriasDto);

        return Created($"/api/[controller]/{response.data.id}", response); 
    }
    
    
    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<CategoriasDto>>> GetByID(int id)
    {
        var response = new Response<CategoriasDto>();
        
        if (!await _categoriasService.CategoriasExist(id))
        {
            response.Errors.Add("Categorias not found");
            return NotFound(response);
        }
        
        var product = await _categoriasService.GetById(id);
        
        response.data = product;
        response.Message = "Categorias found";
        
        return Ok(response);
    }
    
    
    [HttpPut]
    public async Task<ActionResult<Response<CategoriasDto>>> Put([FromBody] CategoriasDto categoriasDto)
    {
        var response = new Response<CategoriasDto>();
        
        if (!await _categoriasService.CategoriasExist(categoriasDto.id))
        {
            response.Errors.Add("Categorias not found");
            return NotFound(response);
        }
        
        response.data = await _categoriasService.UpdateAsync(categoriasDto);
        
        return Ok(response);
    }
    
    
    [HttpDelete]
    public async Task<ActionResult<Response<bool>>> Delete(int id)
    {
        var response = new Response<bool>();
        
        if (!await _categoriasService.CategoriasExist(id))
        {
            response.Errors.Add("Categorias not found");
            return NotFound(response);
        }
        
        response.data = await _categoriasService.DeleteAsync(id);
        
        return Ok(response);
    }
}