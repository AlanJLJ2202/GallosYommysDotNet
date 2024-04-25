using GallosYommys.Core.Entities;
using GallosYommys.Core.Http;
using GallosYommys.WebAPI.Dto;
using GallosYommys.WebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GallosYommys.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ListaProductosController : ControllerBase
{
    private readonly IListaProductosService _listaProductosService;
    
    public ListaProductosController(IListaProductosService listaProductosService)
    {
        _listaProductosService = listaProductosService;
    }
    
    [HttpGet]
    public async Task<ActionResult<Response<List<ListaProductos>>>> GetAll(int lista_id)
    {
        var response = new Response<List<ListaProductosDto>>();
        response.data = await _listaProductosService.GetAllAsync(lista_id);
        
        return Ok(response);
    }
    
    
    [HttpPost]
    public async Task<ActionResult<Response<ListaProductosDto>>> Post([FromBody] ListaProductosDto listaProductosDto)
    {
        var response = new Response<ListaProductosDto>();
        response.data = await _listaProductosService.SaveAsync(listaProductosDto);

        return Created($"/api/[controller]/{response.data.id}", response); 
    }


    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<ListaProductosDto>>> GetByID(int id)
    {
        var response = new Response<ListaProductosDto>();
        
        if (!await _listaProductosService.ListaProductosExist(id))
        {
            response.Errors.Add("ListaProductos not found");
            return NotFound(response);
        }
        
        var product = await _listaProductosService.GetById(id);
        
        response.data = product;
        response.Message = "ListaProductos found";
        
        return Ok(response);
    }
    
    
    [HttpPut]
    public async Task<ActionResult<Response<ListaProductosDto>>> Put([FromBody] ListaProductosDto listaProductosDto)
    {
        var response = new Response<ListaProductosDto>();
        
        if (!await _listaProductosService.ListaProductosExist(listaProductosDto.id))
        {
            response.Errors.Add("ListaProductos not found");
            return NotFound(response);
        }
        
        response.data = await _listaProductosService.UpdateAsync(listaProductosDto);
        
        return Ok(response);
    }
    
    
    [HttpDelete]
    public async Task<ActionResult<Response<bool>>> Delete(int id)
    {
        var response = new Response<bool>();
        
        if (!await _listaProductosService.ListaProductosExist(id))
        {
            response.Errors.Add("ListaProductos not found");
            return NotFound(response);
        }
        
        response.data = await _listaProductosService.DeleteAsync(id);
        
        return Ok(response);
    }
    
}