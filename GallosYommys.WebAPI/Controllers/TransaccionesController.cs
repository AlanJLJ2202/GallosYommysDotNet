using GallosYommys.Core.Entities;
using GallosYommys.Core.Http;
using GallosYommys.WebAPI.Dto;
using GallosYommys.WebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GallosYommys.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TransaccionesController : ControllerBase
{

    private readonly ITransaccionesService _transaccionesService;
    
    public TransaccionesController(ITransaccionesService transaccionesService)
    {
        _transaccionesService = transaccionesService;
    }

    [HttpGet]
    public async Task<ActionResult<Response<List<Transacciones>>>> GetAll()
    {
        var response = new Response<List<TransaccionesDto>>();
        response.data = await _transaccionesService.GetAllAsync();

        return Ok(response);
    }


    [HttpPost]
    public async Task<ActionResult<Response<TransaccionesDto>>> Post([FromBody] TransaccionesDto transaccionesDto)
    {
        var response = new Response<TransaccionesDto>();
        response.data = await _transaccionesService.SaveAsync(transaccionesDto);

        return Created($"/api/[controller]/{response.data.id}", response); 
    }


    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<TransaccionesDto>>> GetByID(int id)
    {
        var response = new Response<TransaccionesDto>();
        
        if (!await _transaccionesService.TransaccionesExist(id))
        {
            response.Errors.Add("Transacciones not found");
            return NotFound(response);
        }
        
        var product = await _transaccionesService.GetById(id);
        
        response.data = product;
        response.Message = "Transacciones found";
        
        return Ok(response);
    }


    [HttpPut]
    public async Task<ActionResult<Response<TransaccionesDto>>> Put([FromBody] TransaccionesDto transaccionesDto)
    {
        var response = new Response<TransaccionesDto>();
        
        try
        {
            response.data = await _transaccionesService.UpdateAsync(transaccionesDto);
        }
        catch (Exception ex)
        {
            response.Errors.Add(ex.Message);
            return BadRequest(response);
        }

        return Ok(response);
    }
    
    
    [HttpDelete]
    public async Task<ActionResult<Response<TransaccionesDto>>> Delete(int id)
    {
        var response = new Response<bool>();
        
        if (!await _transaccionesService.TransaccionesExist(id))
        {
            response.Errors.Add("Transacciones not found");
            return NotFound(response);
        }
        
        response.data = await _transaccionesService.DeleteAsync(id);
        
        return Ok(response);
    }
    


}