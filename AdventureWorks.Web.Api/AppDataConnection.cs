using LinqToDB.Configuration;
using LinqToDB.Data;

namespace AdventureWorks.Web.Api
{
    public class AppDataConnection : DataConnection
    {
        public AppDataConnection(LinqToDBConnectionOptions<AppDataConnection> options)
            : base(options)
        {
        }
    }
}
