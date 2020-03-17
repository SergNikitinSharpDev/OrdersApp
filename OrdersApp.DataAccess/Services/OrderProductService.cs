using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using OrdersApp.DataAccess.Interfaces;
using OrdersApp.Domain;
using OrdersApp.Models.Entities;
using OrdersApp.Models.View;

namespace OrdersApp.DataAccess.Services
{
    public class OrderProductService : IOrderProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<TestOrderProduct>> GetAllAsync()
        {
            var result = _unitOfWork.TestOrderProducts.GetBaseQuery().Include(x => x.Order).Include(x => x.Product);
            return await result.ToListAsync();
        }

        public async Task<IEnumerable<TestOrderProduct>> GetAllByOrderAsync(int orderId)
        {
            var result = _unitOfWork.TestOrderProducts.GetBaseQuery().Include(x => x.Order).Include(x => x.Product).Where(x => x.OrderId == orderId);
            return await result.ToListAsync();
        }

        public async Task<IEnumerable<GroupOrdersResult>> GroupOrders(IEnumerable<int> orderIds)
        {
            return await _unitOfWork.StoredProcedures.GroupOrdersByAddressAndCategory(orderIds);
        }
    }
}