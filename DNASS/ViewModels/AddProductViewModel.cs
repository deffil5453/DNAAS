namespace DNASS.ViewModels
{
    public class AddProductViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Cost { get; set; }
        public int CategoryId { get; set; }
        public decimal Skidka { get; set; }
        public string ImgUrl { get; set; }
        public Guid CategotyId { get; set; }
    }
}
