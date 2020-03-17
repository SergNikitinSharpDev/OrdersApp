using OrdersApp.Domain.Interfaces;
using OrdersApp.Models.Entities;

namespace OrdersApp.Domain
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(
            IBaseRepository<TestCategory> testCategories,
            IBaseRepository<TestProduct> testProducts,
            IBaseRepository<TestOrder> testOrders,
            IBaseRepository<TestProductCategory> testProductCategories, 
            IBaseRepository<TestOrderProduct> testOrderProducts,
            IStoredProceduresContainer storedProcedures)
        {
            TestCategories = testCategories;
            TestProducts = testProducts;
            TestOrders = testOrders;
            TestProductCategories = testProductCategories;
            TestOrderProducts = testOrderProducts;
            StoredProcedures = storedProcedures;
        }

        public IBaseRepository<TestCategory> TestCategories { get; }
        public IBaseRepository<TestProduct> TestProducts { get; }
        public IBaseRepository<TestOrder> TestOrders { get; }
        public IBaseRepository<TestProductCategory> TestProductCategories { get; }
        public IBaseRepository<TestOrderProduct> TestOrderProducts { get; }
        public IStoredProceduresContainer StoredProcedures { get; }
    }
}