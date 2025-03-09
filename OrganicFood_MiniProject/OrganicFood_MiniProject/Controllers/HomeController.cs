using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrganicFood_MiniProject.Data;
using OrganicFood_MiniProject.Models;
using OrganicFood_MiniProject.ViewModels;
using System.Diagnostics;

namespace OrganicFood_MiniProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<Slider> sliders = await _context.Sliders.ToListAsync();

            SliderImage image = await _context.SliderImages.FirstOrDefaultAsync();

            var sliderVM = sliders.Select(slider => new SliderVM
            {
                FirstTitle = slider.FirstTitle,
                SecondTitle = slider.SecondTitle,
                Description = slider.Description,
                Image = slider.Image
            }).ToList();

            var homeVM = new HomeVM
            {
                Sliders = sliderVM,
                Img = image
            };

            return View(homeVM);
        }

    }
}
           

