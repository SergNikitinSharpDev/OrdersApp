using System.ComponentModel.DataAnnotations.Schema;
using OrdersApp.Models.Base;

namespace OrdersApp.Models.Entities
{
    public class TestCategory : IBaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //Int is bad decision. Use GUID
        public int Id { get; set; }
        public string Name { get; set; }
    }
}