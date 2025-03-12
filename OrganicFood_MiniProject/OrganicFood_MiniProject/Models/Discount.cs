namespace OrganicFood_MiniProject.Models
{
    public class Discount : BaseEntity
    {
        public decimal DiscountPercentage { get; set; }
        public ICollection<ProductDiscount> ProductDiscounts { get; set; }
    }
}
