using GallosYommys.Core.Entities;
using GallosYommys.Core.Http;
using GallosYommys.WebAPI.Dto;
using GallosYommys.WebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GallosYommys.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BalancesController : ControllerBase
{
    
    private readonly IBalancesService _balancesService;
    
    public BalancesController(IBalancesService balancesService)
    {
        _balancesService = balancesService;
    }

    [HttpGet]
    public async Task<ActionResult<Response<List<Balances>>>> GetAll()
    {
        var response = new Response<List<BalancesDto>>();
        response.data = await _balancesService.GetAllAsync();

        return Ok(response);
    }
    
    
    [HttpPost]
    public async Task<ActionResult<Response<BalancesDto>>> Post([FromBody] BalancesDto balancesDto)
    {
        var response = new Response<BalancesDto>();
        response.data = await _balancesService.SaveAsync(balancesDto);

        return Created($"/api/[controller]/{response.data.id}", response); 
    }


    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<BalancesDto>>> GetByID(int id)
    {
        var response = new Response<BalancesDto>();

        if (!await _balancesService.BalancesExist(id))
        {
            response.Errors.Add("Balances not found");
            return NotFound(response);
        }

        var product = await _balancesService.GetById(id);

        response.data = product;
        response.Message = "Balances found";

        return Ok(response);
    }
    
    
    [HttpGet]
    [Route("user/{userId:int}")]
    public async Task<ActionResult<Response<BalancesDto>>> GetByUserId(int userId)
    {
        var response = new Response<BalancesDto>();

        // if (!await _balancesService.BalancesExist(userId))
        // {
        //     response.Errors.Add("Balances not found");
        //     return NotFound(response);
        // }

        var product = await _balancesService.GetByUserId(userId);

        response.data = product;
        response.Message = "Balances found";

        return Ok(response);
    }
    
    
    [HttpPut]
    public async Task<ActionResult<Response<BalancesDto>>> Put([FromBody] BalancesDto balancesDto)
    {
        var response = new Response<BalancesDto>();
        
        try
        {
            response.data = await _balancesService.UpdateAsync(balancesDto);
        }
        catch (Exception e)
        {
            response.Errors.Add(e.Message);
            return BadRequest(response);
        }

        return Ok(response);
    }
    
    
    [HttpDelete]
    public async Task<ActionResult<Response<bool>>> Delete(int id)
    {
        var response = new Response<bool>();
        
        try
        {
            response.data = await _balancesService.DeleteAsync(id);
        }
        catch (Exception e)
        {
            response.Errors.Add(e.Message);
            return BadRequest(response);
        }

        return Ok(response);
    }


}