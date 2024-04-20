using GallosYommys.Core.Entities;

namespace GallosYommys.WebAPI.Dto;

public class ProductDto : DtoBase
{
    public string Name { get; set; }
    public string Description { get; set; }
    
    public ProductDto()
    {
        
    }
    public ProductDto(Products product)
    {
        id = product.id;
        Name = product.Name;
        Description = product.Description;
    }
    
}