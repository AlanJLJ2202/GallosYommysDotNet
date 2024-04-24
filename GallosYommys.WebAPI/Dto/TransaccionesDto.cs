using GallosYommys.Core.Entities;

namespace GallosYommys.WebAPI.Dto;

public class TransaccionesDto : DtoBase
{
    public int user_id { get; set; }
    
    public string tipo { get; set; }
    
    public string descripcion { get; set; }
    
    public DateTime fecha { get; set; }

    
    public double monto { get; set; }


    public TransaccionesDto()
    {
        
    }

    public TransaccionesDto(Transacciones transacciones)
    {
        id = transacciones.id;
        user_id = transacciones.user_id;
        monto = transacciones.monto;
        tipo = transacciones.tipo;
        descripcion = transacciones.descripcion;
        fecha = transacciones.fecha;
    }
}