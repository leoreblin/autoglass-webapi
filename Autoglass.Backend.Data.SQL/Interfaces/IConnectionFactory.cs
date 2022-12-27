using System.Data;

namespace Autoglass.Backend.Data.SQL.Interfaces
{
    public interface IConnectionFactory 
    {
        IDbConnection GetOpenConnection();
    }
}
