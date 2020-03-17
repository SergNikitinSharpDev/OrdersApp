using OrdersApp.Domain.Interfaces;
using OrdersApp.Models.View;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersApp.Domain.Services
{
    public class StoredProceduresContainer : IStoredProceduresContainer
    {
        private readonly ApplicationDbContext _dbContext;

        public StoredProceduresContainer(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<GroupOrdersResult>> GroupOrdersByAddressAndCategory(IEnumerable<int> orderIds)
        {
            var dataTable = new DataTable();
            dataTable.TableName = "dbo.IDList";
            dataTable.Columns.Add("ID", typeof(int));
            foreach (var id in orderIds)
            {
                dataTable.Rows.Add(id);
            }

            var param = new SqlParameter("orderIds", SqlDbType.Structured);
            param.TypeName = "dbo.IDList";
            param.Value = dataTable;

            var objContext = ((IObjectContextAdapter)_dbContext).ObjectContext;

            var result = await objContext.ExecuteStoreQueryAsync<GroupOrdersResult>("EXEC GroupOrdersByAddressAndCategory @orderIds", param);

            return result;
        }
    }
}
