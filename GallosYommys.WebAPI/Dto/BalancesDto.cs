using GallosYommys.Core.Entities;

namespace GallosYommys.WebAPI.Dto;

public class BalancesDto : DtoBase
{
    public int user_id { get; set; }
    
    public double saldo { get; set; }
    
    public BalancesDto()
    {
        
    }
    
    public BalancesDto(Balances balances)
    {
        id = balances.id;
        user_id = balances.user_id;
        saldo = balances.saldo;
    }
}