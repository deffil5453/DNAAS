using DNASS.Models;

namespace DNASS.ViewModels
{
    public class CreateOrder
    {
        public Guid Name { get; set; }
        public DateOnly DateCreationOrder { get; set; }
        public Guid ProductId { get; set; }
    }
}
