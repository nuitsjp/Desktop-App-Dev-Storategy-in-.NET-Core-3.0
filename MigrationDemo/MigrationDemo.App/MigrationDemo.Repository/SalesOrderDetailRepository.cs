using System.Collections.Generic;
using System.Data;
using Dapper.FastCrud;

namespace MigrationDemo.Repository
{
    public class SalesOrderDetailRepository
    {
        public static IEnumerable<SalesOrderDetail> GetSalesOrderDetail(IDbConnection connection)
        {
            return connection.Find<SalesOrderDetail>();
        }
    }
}