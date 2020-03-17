using OrdersApp.Models.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersApp.Domain.Interfaces
{
    public interface IStoredProceduresContainer
    {
        Task<IEnumerable<GroupOrdersResult>> GroupOrdersByAddressAndCategory(IEnumerable<int> orderIds);
    }
}
