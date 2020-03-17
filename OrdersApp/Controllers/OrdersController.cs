using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Newtonsoft.Json;
using OrdersApp.DataAccess.Interfaces;
using OrdersApp.Models.View;

namespace OrdersApp.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrderProductService _testOrderProductService;
        private readonly IOrderService _testOrderService;
        private readonly IShipmentService _shipmentService;
        public OrdersController(IOrderProductService testOrderProductService,
            IOrderService testOrderService,
            IShipmentService shipmentService)
        {
            _testOrderProductService = testOrderProductService;
            _testOrderService = testOrderService;
            _shipmentService = shipmentService;
        }

        public async Task<ActionResult> Index()
        {
            List<OrderProductModel> result = new List<OrderProductModel>();

            var orders = await _testOrderService.GetAllAsync();

            foreach (var order in orders)
            {
                var obj = new OrderProductModel { Order = order };
                var prods = await _testOrderProductService.GetAllByOrderAsync(order.Id);

                obj.Products = prods.Select(x => new TestProductModel
                {
                    Product = x.Product,
                    Price = x.Price,
                    Total = x.Total,
                    Quantity = x.Quantity
                })
                    .ToList();
                result.Add(obj);
            }

            return View(result);
        }


        [HttpPost]
        public async Task<JsonResult> ProcessOrders(List<int> selectedOrdersIds)
        {
            var result = await _shipmentService.ProcessOrdersAsync(selectedOrdersIds);

            return Json(new DemoResult { Data = result });
        }

        //
        [HttpPost]
        public async Task<JsonResult> Orders(List<ShipmentModel> model)
        {
            // return the input for demonstration purposes
            return Json(new DemoResult { Data = model });
        }

    }
}