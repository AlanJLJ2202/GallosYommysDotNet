using System.Data.Common;

namespace GallosYommys.WebAPI.DataAccess.Interfaces;

public interface IDbContext
{
    
    DbConnection Connection { get; }
    
}