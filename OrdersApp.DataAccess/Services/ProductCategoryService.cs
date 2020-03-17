using System.Data.Entity;
using System.Linq;
using OrdersApp.DataAccess.Interfaces;
using OrdersApp.Domain;
using OrdersApp.Models.Entities;

namespace OrdersApp.DataAccess.Services
{
    public class ProductCategoryService: IProductCategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductCategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public TestProductCategory GetByProductId(int productId)
        {
            return _unitOfWork.TestProductCategories.GetBaseQuery().Include(x=>x.Product).Include(x=>x.Category).FirstOrDefault(x => x.ProductId == productId);
        }
    }
}