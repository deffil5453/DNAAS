using System.ComponentModel.DataAnnotations;

namespace DNASS.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        [Required] public Guid Name { get; set; }
        [Required] public DateOnly DateCreationOrder { get; set; }
        [Required]public Guid ProductId { get; set; }
        public string UserId {  get; set; }
        public User User {  get; set; }
        public List<OrderProduct> OrdersProduct { get; set; }
    }
}
