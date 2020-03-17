using OrdersApp.Models.Entities;

namespace OrdersApp.DataAccess.Interfaces
{
    public interface IProductCategoryService
    {
        TestProductCategory GetByProductId(int productId);
    }
}