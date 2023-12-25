using System.ComponentModel.DataAnnotations;

namespace DNASS.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        [Required]public string Name { get; set; }
        public string Description { get; set; }
        public decimal Cost { get; set; }
        public decimal Skidka { get; set; }
        public string ImgUrl { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public List<OrderProduct> OrdersProduct { get; set;}
    }
}
