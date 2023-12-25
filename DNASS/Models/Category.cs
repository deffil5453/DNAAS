using System.ComponentModel.DataAnnotations;

namespace DNASS.Models
{
    public class Category
    {
        [Required]public int Id { get; set; }
        [Required]public string Name { get; set; }
        public Product Product { get; set; }
    }
}
