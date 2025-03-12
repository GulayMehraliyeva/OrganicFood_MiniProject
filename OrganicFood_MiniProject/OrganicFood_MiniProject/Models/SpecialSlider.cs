namespace OrganicFood_MiniProject.Models
{
    public class SpecialSlider : BaseEntity
    {
        public string FirstText { get; set; }
        public string SecondText { get; set; }
        public string ThirdText { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal DiscountedPrice { get; set; }
        public string Img { get; set; }
    }
}
