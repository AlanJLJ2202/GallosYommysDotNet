using GallosYommys.Core.Entities;
using GallosYommys.Core.Http;
using GallosYommys.WebAPI.Dto;
using GallosYommys.WebAPI.Repositories.Interfaces;
using GallosYommys.WebAPI.Services.Interfaces;

namespace GallosYommys.WebAPI.Services;

public class ListaProductosService : IListaProductosService
{
    
    private readonly IListaProductosRepository _listaProductosRepository;
    //private readonly string _domain;
    
    public ListaProductosService(IListaProductosRepository listaProductosRepository)
    {
        _listaProductosRepository = listaProductosRepository;
        //_domain = domain;
    }
    
    public async Task<bool> ListaProductosExist(int id)
    {
        var listaProductos = await _listaProductosRepository.GetById(id);
        return (listaProductos != null);
    }
    
    public async Task<ListaProductosDto> SaveAsync(ListaProductosDto listaProductos)
    {
        var listaProductosEntity = new ListaProductos
        {
            lista_compra_id = listaProductos.lista_compra_id,
            producto_id = listaProductos.producto_id,
            cantidad = listaProductos.cantidad,
            precio_compra = listaProductos.precio_compra,
            producto_nombre = listaProductos.producto_nombre,
            producto_descripcion = listaProductos.producto_descripcion,
            CreatedBy = "",
            CreatedDate = DateTime.Now,
            UpdatedBy = "",
            UpdatedDate = DateTime.Now
        };
        
        listaProductosEntity = await _listaProductosRepository.SaveAsync(listaProductosEntity);
        listaProductos.id = listaProductosEntity.id;

        return listaProductos;
    }
    
    
    public async Task<ListaProductosDto> UpdateAsync(ListaProductosDto listaProductos)
    {
        var response = new Response<ListaProductos>();
        var listaProductosEntity = await _listaProductosRepository.GetById(listaProductos.id);

        if (listaProductosEntity == null)
            throw new Exception("listaProductos not found");
            
        listaProductosEntity.lista_compra_id = listaProductos.lista_compra_id;
        listaProductosEntity.producto_id = listaProductos.producto_id;
        listaProductosEntity.cantidad = listaProductos.cantidad;
        listaProductosEntity.precio_compra = listaProductos.precio_compra;
        listaProductosEntity.producto_nombre = listaProductos.producto_nombre;
        listaProductosEntity.producto_descripcion = listaProductos.producto_descripcion;
        listaProductosEntity.UpdatedBy = "";
        listaProductosEntity.UpdatedDate = DateTime.Now;
        
        listaProductosEntity = await _listaProductosRepository.UpdateAsync(listaProductosEntity);
        listaProductos.id = listaProductosEntity.id;

        return listaProductos;
    }
    
    
    public async Task<List<ListaProductosDto>> GetAllAsync()
    {
        var listaProductos = await _listaProductosRepository.GetAllAsync();
        return listaProductos.Select(x => new ListaProductosDto(x)).ToList();
    }

    public async Task<ListaProductosDto?> GetById(int id)
    {
        var listaProductos = await _listaProductosRepository.GetById(id);

        if (listaProductos == null)
            return null;

        return new ListaProductosDto
        {
            id = listaProductos.id,
            lista_compra_id = listaProductos.lista_compra_id,
            producto_id = listaProductos.producto_id,
            cantidad = listaProductos.cantidad,
            precio_compra = listaProductos.precio_compra,
            producto_nombre = listaProductos.producto_nombre,
            producto_descripcion = listaProductos.producto_descripcion
        };

    }
    
    
    public async Task<bool> DeleteAsync(int id)
    {
        return await _listaProductosRepository.DeleteAsync(id);
    }
}