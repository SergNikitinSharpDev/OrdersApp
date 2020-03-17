using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrdersApp.DataAccess.Interfaces;
using OrdersApp.Models.View;

namespace OrdersApp.DataAccess.Services
{
    public class ShipmentService : IShipmentService
    {
        private readonly IOrderProductService _testOrderProductService;
        private readonly IProductCategoryService _testProductCategoryService;

        public ShipmentService(
            IProductCategoryService testProductCategoryService, 
            IOrderProductService testOrderProductService)
        {
            _testProductCategoryService = testProductCategoryService;
            _testOrderProductService = testOrderProductService;
        }

        public async Task<List<ShipmentModel>> ProcessOrdersAsync(List<int> selectedOrdersIds)
        {
            var prods = await _testOrderProductService.GroupOrders(selectedOrdersIds);

            var grouped = prods.GroupBy(x => new
            {
                x.FirstName,
                x.LastName,
                x.Address,
                x.City,
                x.State,
                x.Country,
                x.ShipmentId
            }).OrderBy(x => x.Key.ShipmentId);

            return grouped.Select(x => new ShipmentModel
            {
                ShipmentId = x.Key.ShipmentId,
                FirstName = x.Key.FirstName,
                LastName = x.Key.LastName,
                Address = x.Key.Address,
                City = x.Key.City,
                State = x.Key.State,
                Country = x.Key.Country,
                Products = x.Select(r => new ShipmentProductModel
                { SKU = r.SKU, Quantity = r.Quantity })
            }).ToList();
        }
    }
}