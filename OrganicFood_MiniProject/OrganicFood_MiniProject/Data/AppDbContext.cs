using Microsoft.EntityFrameworkCore;
using OrganicFood_MiniProject.Models;

namespace OrganicFood_MiniProject.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> option) : base(option) { }

        public DbSet<Slider> Sliders { get; set; }
        public DbSet<SliderImage> SliderImages { get; set; }
    }
}
