using System.ComponentModel.DataAnnotations.Schema;
using OrdersApp.Models.Base;

namespace OrdersApp.Models.Entities
{
    public class TestProduct : IBaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string SKU { get; set; }
        public string Description { get; set; }

    }
}