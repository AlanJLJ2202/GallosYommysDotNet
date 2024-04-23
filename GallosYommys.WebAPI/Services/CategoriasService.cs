using GallosYommys.Core.Entities;
using GallosYommys.Core.Http;
using GallosYommys.WebAPI.Dto;
using GallosYommys.WebAPI.Repositories.Interfaces;
using GallosYommys.WebAPI.Services.Interfaces;

namespace GallosYommys.WebAPI.Services;

public class CategoriasService : ICategoriasService
{
    
    private readonly ICategoriasRepository _categoriasRepository;
    
    public CategoriasService(ICategoriasRepository categoriasRepository)
    {
        _categoriasRepository = categoriasRepository;
    }
    
    
    public async Task<bool> CategoriasExist(int id)
    {
        var categorias = await _categoriasRepository.GetById(id);
        return (categorias != null);
    }
    
    public async Task<CategoriasDto> SaveAsync(CategoriasDto categorias)
    {
        var categoriasEntity = new Categorias
        {
            nombre = categorias.nombre,
            CreatedBy = "",
            CreatedDate = DateTime.Now,
            UpdatedBy = "",
            UpdatedDate = DateTime.Now
        };
        
        categoriasEntity = await _categoriasRepository.SaveAsync(categoriasEntity);
        categorias.id = categoriasEntity.id;

        return categorias;
    }
    
    
    public async Task<CategoriasDto> UpdateAsync(CategoriasDto categorias)
    {
        var response = new Response<Categorias>();
        var categoriasEntity = await _categoriasRepository.GetById(categorias.id);

        if (categoriasEntity == null)
            throw new Exception("categorias not found");
            
        categoriasEntity.nombre = categorias.nombre;
        categoriasEntity.UpdatedBy = "";
        categoriasEntity.UpdatedDate = DateTime.Now;
        
        categoriasEntity = await _categoriasRepository.UpdateAsync(categoriasEntity);

        return categorias;
    }
    
    public async Task<List<CategoriasDto>> GetAllAsync()
    {
        var categorias = await _categoriasRepository.GetAllAsync();
        return categorias.Select(c => new CategoriasDto
        {
            id = c.id,
            nombre = c.nombre
        }).ToList();
    }
    
    //get by id
    public async Task<CategoriasDto?> GetById(int id)
    {
        var categorias = await _categoriasRepository.GetById(id);
        
        if (categorias == null)
        {
            return null;
        }
        
        return new CategoriasDto(categorias);
    }
    
    public async Task<bool> DeleteAsync(int id)
    {
        return await _categoriasRepository.DeleteAsync(id);
    }
    
}