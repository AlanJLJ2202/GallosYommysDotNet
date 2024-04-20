using Microsoft.AspNetCore.Mvc;
using GallosYommys.Core.Entities;
using GallosYommys.Core.Http;
using GallosYommys.WebAPI.Dto;
using GallosYommys.WebAPI.Services.Interfaces;

namespace GallosYommys.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    
    private readonly IProductService _productService;
    
    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }
    
    [HttpGet]
    public async Task<ActionResult <Response<List<Products>>>> GetAll()
    {
        var response = new Response<List<ProductDto>>
        {
            data = await _productService.GetAllAsync()
        };
        
        return Ok(response);
    }   
    
    
    [HttpPost]
    public async Task<ActionResult<Response<ProductDto>>> Post([FromBody] ProductDto productDto)
    {
        var response = new Response<ProductDto>()
        {
            data = await _productService.SaveAsync(productDto)
        };

        return Created($"/api/[controller]/{response.data.id}", response); 
    }
    
    
    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<ProductDto>>> GetByID(int id)
    {
        var response = new Response<ProductDto>();
        
        if (!await _productService.ProductExist(id))
        {
            response.Errors.Add("Product not found");
            return NotFound(response);
        }
        
        var product = await _productService.GetById(id);
        
        response.data = product;
        response.Message = "Product found";
        
        return Ok(response);
    }
    
    
    [HttpPut]
    public async Task<ActionResult<Response<ProductDto>>> Update([FromBody] ProductDto productDto)
    {
        var response = new Response<ProductDto>();
        
        try
        {
            response.data = await _productService.UpdateAsync(productDto);
        }
        catch (Exception ex)
        {
            response.Errors.Add(ex.Message);
            return BadRequest(response);
        }
        
        return Ok(response);
    }
    
    
    [HttpDelete]
    public async Task<ActionResult<Response<bool>>> Delete(int id)
    {
        var response = new Response<bool>();
        
        if (!await _productService.ProductExist(id))
        {
            response.Errors.Add("Product not found");
            return NotFound(response);
        }
        
        response.data = await _productService.DeleteAsync(id);
        
        return Ok(response);
    }
}