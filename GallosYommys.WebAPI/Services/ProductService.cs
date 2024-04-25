using GallosYommys.Core.Entities;
using GallosYommys.Core.Http;
using GallosYommys.WebAPI.Dto;
using GallosYommys.WebAPI.Repositories.Interfaces;
using GallosYommys.WebAPI.Services.Interfaces;

namespace GallosYommys.WebAPI.Services;

public class ProductService : IProductService
{
    
    private readonly IProductRepository _productRepository;
    //private readonly string _domain;

    
    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
        //_domain = domain;
    }
    
    
    public async Task<bool> ProductExist(int id)
    {
        var product = await _productRepository.GetById(id);
        return (product != null);
    }
    
    public async Task<ProductDto> SaveAsync(ProductDto product)
    {
        var productEntity = new Products
        {
            user_id = product.user_id,
            Name = product.Name,
            Description = product.Description,
            precio_compra = product.precio_compra,
            CreatedBy = "",
            CreatedDate = DateTime.Now,
            UpdatedBy = "",
            UpdatedDate = DateTime.Now
        };
        
        productEntity = await _productRepository.SaveAsync(productEntity);
        product.id = productEntity.id;

        return product;
    }
    
    
    public async Task<ProductDto> UpdateAsync(ProductDto product)
    {
        var response = new Response<Products>();
        var productEntity = await _productRepository.GetById(product.id);

        if (productEntity == null)
            throw new Exception("product not found");
            
        productEntity.user_id = product.user_id;
        productEntity.Name = product.Name;
        productEntity.Description = product.Description;
        productEntity.precio_compra = product.precio_compra;    
        productEntity.UpdatedBy = "";
        productEntity.UpdatedDate = DateTime.Now;
        
        await _productRepository.UpdateAsync(productEntity);

        return product;
    }
    
    
    public async Task<List<ProductDto>> GetAllAsync(int user_id)
    {
        
        var products = await _productRepository.GetAllAsync(user_id);
        
        
        
        return products.Select(p => new ProductDto
        {
            id = p.id,
            user_id = p.user_id,
            Name = p.Name,
            Description = p.Description,
            precio_compra = p.precio_compra
        }).ToList();
    }
    
    
    public async Task<bool> DeleteAsync(int id)
    {
        return await _productRepository.DeleteAsync(id);
    }
    
    
    public async Task<ProductDto?> GetById(int id)
    {
        var product = await _productRepository.GetById(id);
        
        if (product == null)
            return null;
        
        return new ProductDto
        {
            id = product.id,
            Name = product.Name,
            Description = product.Description
        };
    }
    
}