using System.Data;

namespace ExternalResources.Db.Providers
{
    public interface IConnectionProvide
    {
        IDbConnection GetOpenConnection();

    }
}