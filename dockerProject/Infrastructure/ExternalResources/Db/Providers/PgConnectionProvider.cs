using System.Data;
using Npgsql;

namespace ExternalResources.Db.Providers
{
    public class PgPgConnectionProvider : IPgConnectionProvider
    {
        private readonly string _pgConnectionString;

        public PgPgConnectionProvider(string pgConnectionString)
        {
            _pgConnectionString = pgConnectionString;
        }

        public IDbConnection GetOpenConnection()
        {
            var connection = NpgsqlFactory.Instance.CreateConnection();
            connection.ConnectionString = _pgConnectionString;
            connection.Open();
            return connection;
        }
    }


    public interface IPgConnectionProvider:IConnectionProvide
    {
    }
}