using GallosYommys.Core.Entities;
using GallosYommys.Core.Http;
using GallosYommys.WebAPI.Dto;
using GallosYommys.WebAPI.Repositories.Interfaces;
using GallosYommys.WebAPI.Services.Interfaces;

namespace GallosYommys.WebAPI.Services;

public class ListaComprasService : IListaComprasService
{
    
    private readonly IListaComprasRepository _listaComprasRepository;
    
    public ListaComprasService(IListaComprasRepository listaComprasRepository)
    {
        _listaComprasRepository = listaComprasRepository;
    }
    
    public async Task<bool> ListaComprasExist(int id)
    {
        var listaCompras = await _listaComprasRepository.GetById(id);
        return (listaCompras != null);
    }
    
    public async Task<ListaComprasDto> SaveAsync(ListaComprasDto listaCompras)
    {
        var listaComprasEntity = new ListaCompras
        {
            nombre = listaCompras.nombre,
            fecha = listaCompras.fecha,
            CreatedBy = "",
            CreatedDate = DateTime.Now,
            UpdatedBy = "",
            UpdatedDate = DateTime.Now
        };
        
        listaComprasEntity = await _listaComprasRepository.SaveAsync(listaComprasEntity);
        listaCompras.id = listaComprasEntity.id;

        return listaCompras;
    }
    
    
    public async Task<ListaComprasDto> UpdateAsync(ListaComprasDto listaCompras)
    {
        var response = new Response<ListaCompras>();
        var listaComprasEntity = await _listaComprasRepository.GetById(listaCompras.id);

        if (listaComprasEntity == null)
            throw new Exception("listaCompras not found");
            
        listaComprasEntity.nombre = listaCompras.nombre;
        listaComprasEntity.fecha = listaCompras.fecha;
        listaComprasEntity.UpdatedBy = "";
        listaComprasEntity.UpdatedDate = DateTime.Now;
        
        listaComprasEntity = await _listaComprasRepository.UpdateAsync(listaComprasEntity);

        return listaCompras;
    }
    
    
    public async Task<List<ListaComprasDto>> GetAllAsync()
    {
        var listaCompras = await _listaComprasRepository.GetAllAsync();
        return listaCompras.Select(x => new ListaComprasDto(x)).ToList();
    }

    public async Task<ListaComprasDto?> GetById(int id)
    {
        var listaCompras = await _listaComprasRepository.GetById(id);

        if (listaCompras == null)
        {
            return null;
        }
        
        return new ListaComprasDto(listaCompras);
    }


    public async Task<bool> DeleteAsync(int id)
    {
        return await _listaComprasRepository.DeleteAsync(id);
    }
    
    
    
    
}