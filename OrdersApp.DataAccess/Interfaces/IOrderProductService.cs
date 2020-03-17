using System.Collections.Generic;
using System.Threading.Tasks;
using OrdersApp.Models.Entities;
using OrdersApp.Models.View;

namespace OrdersApp.DataAccess.Interfaces
{
    public interface IOrderProductService
    {
        Task<IEnumerable<TestOrderProduct>> GetAllAsync();
        Task<IEnumerable<TestOrderProduct>> GetAllByOrderAsync(int orderId);
        Task<IEnumerable<GroupOrdersResult>> GroupOrders(IEnumerable<int> orderIds);
    }
}