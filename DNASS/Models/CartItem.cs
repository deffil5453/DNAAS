namespace DNASS.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public Guid ProductId { get; set; }
        public string UserId { get; set; }
        public Product Product { get; set; }
        public User User { get; set; }
    }
}
