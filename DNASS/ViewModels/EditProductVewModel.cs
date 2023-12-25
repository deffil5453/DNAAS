namespace DNASS.ViewModels
{
    public class EditProductVewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Cost { get; set; }
        public decimal Skidka { get; set; }
        public string ImgUrl { get; set; }
        public int CategoryId { get; set; }
    }
}
