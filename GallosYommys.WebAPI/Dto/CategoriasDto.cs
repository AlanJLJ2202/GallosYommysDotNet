using GallosYommys.Core.Entities;

namespace GallosYommys.WebAPI.Dto;

public class CategoriasDto : DtoBase
{
    
    public int user_id { get; set; }
    
    public string nombre { get; set; }
    
    public CategoriasDto()
    {
        
    }
    
    public CategoriasDto(Categorias categorias)
    {
        id = categorias.id;
        user_id = categorias.user_id;
        nombre = categorias.name;
    }
    
}