using System;
using System.Collections.Generic;

namespace OrdersApp.Models.View
{
    public class ShipmentModel
    {
        public long ShipmentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public IEnumerable<ShipmentProductModel> Products { get; set; }
    }

    public class ShipmentProductModel
    {
        public string SKU { get; set; }
        public int Quantity { get; set; }
    }
}