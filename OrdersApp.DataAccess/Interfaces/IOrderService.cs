using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrdersApp.DataAccess.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<Models.Entities.TestOrder>> GetAllAsync();
    }
}