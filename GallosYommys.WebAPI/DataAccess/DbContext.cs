using System.Data.Common;
using MySqlConnector;
using GallosYommys.WebAPI.DataAccess.Interfaces;

namespace GallosYommys.WebAPI.DataAccess;

public class DbContext : IDbContext
{
    
    private readonly IConfiguration _config;
    
    public DbContext(IConfiguration config)
    {
        _config = config;
    }

    //private readonly string _connectionString = "server=localhost;user=root;Password=Jalpa117;database=Ecommerce;port=3306";
    private MySqlConnection _connection;

    public DbConnection Connection
    {
        get
        {
            if (_connection == null)
            {
                _connection = new MySqlConnection(_config.GetConnectionString("DefaultConnection"));
            }
            return _connection;
        }
    }
    
}