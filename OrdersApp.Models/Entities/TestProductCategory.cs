using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OrdersApp.Models.Base;

namespace OrdersApp.Models.Entities
{
    public class TestProductCategory : IBaseEntity
    {
        [Column(Order = 0), Key]
        [Required]
        public int ProductId { get; set; }
        public TestProduct Product { get; set; }

        [Column(Order = 1), Key]
        [Required]
        public int CategoryId { get; set; }
        public TestCategory Category { get; set; }

    }
}