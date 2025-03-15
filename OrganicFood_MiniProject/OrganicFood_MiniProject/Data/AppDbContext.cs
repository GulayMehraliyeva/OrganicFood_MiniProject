using Microsoft.EntityFrameworkCore;
using OrganicFood_MiniProject.Models;

namespace OrganicFood_MiniProject.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> option) : base(option) { }

        public DbSet<Slider> Sliders { get; set; }
        public DbSet<SliderImage> SliderImages { get; set; }
        public DbSet<FreshFruit> FreshFruits { get; set; }
        public DbSet<SpecialSlider> SpecialSliders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductDiscount> ProductDiscounts { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Advertisement> Advertisements { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Blog> Blogs { get; set; }
    }
}
