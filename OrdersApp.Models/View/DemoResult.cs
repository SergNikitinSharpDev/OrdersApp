using System.Collections.Generic;
using Newtonsoft.Json;

namespace OrdersApp.Models.View
{
    //Model for demo purposes
    public class DemoResult
    {
        public  List<ShipmentModel> Data { get; set; } = new List<ShipmentModel>();

        public string Json => JsonConvert.SerializeObject(Data, Formatting.Indented);
    }
}