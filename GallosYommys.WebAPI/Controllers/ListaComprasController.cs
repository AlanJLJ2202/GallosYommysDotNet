using GallosYommys.Core.Entities;
using GallosYommys.Core.Http;
using GallosYommys.WebAPI.Dto;
using GallosYommys.WebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GallosYommys.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ListaComprasController : ControllerBase
{
    
private readonly IListaComprasService _listaComprasService;
    
    public ListaComprasController(IListaComprasService listaComprasService)
    {
        _listaComprasService = listaComprasService;
    }
    
    [HttpGet]
    public async Task<ActionResult<Response<List<ListaCompras>>>> GetAll()
    {
        var response = new Response<List<ListaComprasDto>>();
        response.data = await _listaComprasService.GetAllAsync();
        
        return Ok(response);
    }
    
    
    [HttpPost]
    public async Task<ActionResult<Response<ListaComprasDto>>> Post([FromBody] ListaComprasDto listaComprasDto)
    {
        var response = new Response<ListaComprasDto>();
        response.data = await _listaComprasService.SaveAsync(listaComprasDto);

        return Created($"/api/[controller]/{response.data.id}", response); 
    }
    
    
    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<ListaComprasDto>>> GetByID(int id)
    {
        var response = new Response<ListaComprasDto>();
        
        if (!await _listaComprasService.ListaComprasExist(id))
        {
            response.Errors.Add("ListaCompras not found");
            return NotFound(response);
        }
        
        var product = await _listaComprasService.GetById(id);
        
        response.data = product;
        response.Message = "ListaCompras found";
        
        return Ok(response);
    }
    
    
    [HttpPut]
    public async Task<ActionResult<Response<ListaComprasDto>>> Put([FromBody] ListaComprasDto listaComprasDto)
    {
        var response = new Response<ListaComprasDto>();
        
        if (!await _listaComprasService.ListaComprasExist(listaComprasDto.id))
        {
            response.Errors.Add("ListaCompras not found");
            return NotFound(response);
        }
        
        response.data = await _listaComprasService.UpdateAsync(listaComprasDto);
        
        return Ok(response);
    }
    
    
    [HttpDelete]
    public async Task<ActionResult<Response<bool>>> Delete(int id)
    {
        var response = new Response<bool>();
        
        if (!await _listaComprasService.ListaComprasExist(id))
        {
            response.Errors.Add("ListaCompras not found");
            return NotFound(response);
        }
        
        response.data = await _listaComprasService.DeleteAsync(id);
        
        return Ok(response);
    }
    
    
}