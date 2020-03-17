using System.Collections.Generic;
using System.Threading.Tasks;
using OrdersApp.DataAccess.Interfaces;
using OrdersApp.Domain;

namespace OrdersApp.DataAccess.Services
{
    public class OrderService: IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Models.Entities.TestOrder>> GetAllAsync()
        {
            return await _unitOfWork.TestOrders.GetAllAsync();
        }
    }
}