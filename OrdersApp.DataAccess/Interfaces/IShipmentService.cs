using System.Collections.Generic;
using System.Threading.Tasks;
using OrdersApp.Models.View;

namespace OrdersApp.DataAccess.Interfaces
{
    public interface IShipmentService
    {
        Task<List<ShipmentModel>> ProcessOrdersAsync(List<int> selectedOrdersIds);
    }
}