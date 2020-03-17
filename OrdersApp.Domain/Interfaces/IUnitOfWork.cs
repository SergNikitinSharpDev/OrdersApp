using OrdersApp.Domain.Interfaces;
using OrdersApp.Models.Entities;
using OrdersApp.Models.View;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrdersApp.Domain
{
    public interface IUnitOfWork
    {
        IBaseRepository<TestCategory> TestCategories { get; }
        IBaseRepository<TestProduct> TestProducts { get; }
        IBaseRepository<Models.Entities.TestOrder> TestOrders { get; }
        IBaseRepository<TestProductCategory> TestProductCategories { get; }
        IBaseRepository<TestOrderProduct> TestOrderProducts { get; }
        IStoredProceduresContainer StoredProcedures { get; }
    }
}