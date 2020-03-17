using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OrdersApp.Models.Base;

namespace OrdersApp.Models.Entities
{
    public class TestOrderProduct : IBaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int OrderId { get; set; }
        public TestOrder Order { get; set; }
        [Required]
        public int ProductId { get; set; }
        public TestProduct Product { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public decimal Total { get; set; }


        public string GetAddressIdentity()
        {
            return this.Order == null
                ? string.Empty
                : string.Join("|", this.Order.Address, this.Order.City, this.Order.State, this.Order.Country);
        }

    }
}