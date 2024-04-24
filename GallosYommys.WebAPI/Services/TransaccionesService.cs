using GallosYommys.Core.Entities;
using GallosYommys.Core.Http;
using GallosYommys.WebAPI.Dto;
using GallosYommys.WebAPI.Repositories.Interfaces;
using GallosYommys.WebAPI.Services.Interfaces;

namespace GallosYommys.WebAPI.Services;

public class TransaccionesService : ITransaccionesService
{

    private readonly ITransaccionesRepository _transaccionesRepository;
    
    public TransaccionesService(ITransaccionesRepository transaccionesRepository)
    {
        _transaccionesRepository = transaccionesRepository;
    }

    public async Task<bool> TransaccionesExist(int id)
    {
        var transacciones = await _transaccionesRepository.GetById(id);
        return (transacciones != null);
    }
    
    
    public async Task<TransaccionesDto> SaveAsync(TransaccionesDto transacciones)
    {
        var transaccionesEntity = new Transacciones
        {
            user_id = transacciones.user_id,
            fecha = transacciones.fecha,
            monto = transacciones.monto,
            tipo = transacciones.tipo,
            CreatedBy = "",
            CreatedDate = DateTime.Now,
            UpdatedBy = "",
            UpdatedDate = DateTime.Now
        };
        
        transaccionesEntity = await _transaccionesRepository.SaveAsync(transaccionesEntity);
        transacciones.id = transaccionesEntity.id;

        return transacciones;
    }

    public async Task<TransaccionesDto> UpdateAsync(TransaccionesDto transacciones)
    {
        var response = new Response<Transacciones>();
        var transaccionesEntity = await _transaccionesRepository.GetById(transacciones.id);

        if (transaccionesEntity == null)
            throw new Exception("transacciones not found");

        transaccionesEntity.user_id = transacciones.user_id;
        transaccionesEntity.monto = transacciones.monto;
        transaccionesEntity.tipo = transacciones.tipo;
        transaccionesEntity.descripcion = transacciones.descripcion;
        transaccionesEntity.fecha = transacciones.fecha;
        transaccionesEntity.UpdatedBy = "";
        transaccionesEntity.UpdatedDate = DateTime.Now;

        transaccionesEntity = await _transaccionesRepository.UpdateAsync(transaccionesEntity);

        return transacciones;
    }


    public async Task<List<TransaccionesDto>> GetAllAsync()
    {
        var transacciones = await _transaccionesRepository.GetAllAsync();
        return transacciones.Select(t => new TransaccionesDto
        {
            id = t.id,
            user_id = t.user_id,
            monto = t.monto,
            descripcion = t.descripcion,
            fecha = t.fecha
        }).ToList();
        
    }
    
    
    public async Task<TransaccionesDto?> GetById(int id)
    {
        var transacciones = await _transaccionesRepository.GetById(id);
        
        if (transacciones == null)
        {
            return null;
        }
        
        return new TransaccionesDto(transacciones);
    }


    public async Task<bool> DeleteAsync(int id)
    {
        return await _transaccionesRepository.DeleteAsync(id);
    }

}