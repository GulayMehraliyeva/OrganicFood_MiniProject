using Microsoft.AspNetCore.Mvc;
using OrganicFood_MiniProject.Areas.Admin.ViewModels;
using OrganicFood_MiniProject.Data;
using OrganicFood_MiniProject.Models;

namespace OrganicFood_MiniProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderImageController : Controller
    {
        private readonly AppDbContext _context;
        public SliderImageController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            SliderImage sliderImage = _context.SliderImages.FirstOrDefault();
            if (sliderImage is null) return View(null);
            return View(new SliderImageVM { Id = sliderImage.Id, BackgroundImage = sliderImage.BackgroundImage });
        }
    }
}
