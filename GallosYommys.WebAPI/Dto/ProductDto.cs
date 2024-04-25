using GallosYommys.Core.Entities;

namespace GallosYommys.WebAPI.Dto;

public class ProductDto : DtoBase
{
    public int user_id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    
    public double precio_compra { get; set; }
    
    public ProductDto()
    {
        
    }
    public ProductDto(Products product)
    {
        id = product.id;
        user_id = product.user_id;
        Name = product.Name;
        Description = product.Description;
        precio_compra = product.precio_compra;
    }
    
}