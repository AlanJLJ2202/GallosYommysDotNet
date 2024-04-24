using GallosYommys.Core.Entities;
using GallosYommys.Core.Http;
using GallosYommys.WebAPI.Dto;
using GallosYommys.WebAPI.Repositories.Interfaces;
using GallosYommys.WebAPI.Services.Interfaces;

namespace GallosYommys.WebAPI.Services;

public class BalancesService : IBalancesService
{
    private readonly IBalancesRepository _balancesRepository;
    
    public BalancesService(IBalancesRepository balancesRepository)
    {
        _balancesRepository = balancesRepository;
    }
    
    
    public async Task<bool> BalancesExist(int id)
    {
        var balances = await _balancesRepository.GetById(id);
        return (balances != null);
    }
    
    public async Task<BalancesDto> SaveAsync(BalancesDto balances)
    {
        var balancesEntity = new Balances
        {
            user_id = balances.user_id,
            saldo = balances.saldo,
            CreatedBy = "",
            CreatedDate = DateTime.Now,
            UpdatedBy = "",
            UpdatedDate = DateTime.Now
        };
        
        balancesEntity = await _balancesRepository.SaveAsync(balancesEntity);
        balances.id = balancesEntity.id;

        return balances;
    }
    
    
    public async Task<BalancesDto> UpdateAsync(BalancesDto balances)
    {
        var response = new Response<Balances>();
        var balancesEntity = await _balancesRepository.GetById(balances.id);

        if (balancesEntity == null)
            throw new Exception("balances not found");
            
        balancesEntity.user_id = balances.user_id;
        balancesEntity.saldo = balances.saldo;
        balancesEntity.UpdatedBy = "";
        balancesEntity.UpdatedDate = DateTime.Now;
        
        balancesEntity = await _balancesRepository.UpdateAsync(balancesEntity);

        return balances;
    }
    
    
    public async Task<List<BalancesDto>> GetAllAsync()
    {
        var balances = await _balancesRepository.GetAllAsync();
        return balances.Select(x => new BalancesDto
        {
            id = x.id,
            user_id = x.user_id,
            saldo = x.saldo
        }).ToList();
    }

    public async Task<BalancesDto?> GetById(int id)
    {
        var balances = await _balancesRepository.GetById(id);

        if (balances == null)
        {
            return null;
        }
        
        return new BalancesDto(balances);
    }
    
    
    public async Task<bool> DeleteAsync(int id)
    {
        return await _balancesRepository.DeleteAsync(id);
    }
}