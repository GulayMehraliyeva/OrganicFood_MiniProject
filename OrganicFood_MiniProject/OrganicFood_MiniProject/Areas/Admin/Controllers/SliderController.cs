using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrganicFood_MiniProject.Areas.Admin.ViewModels.Slider;
using OrganicFood_MiniProject.Data;
using OrganicFood_MiniProject.Models;

namespace OrganicFood_MiniProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {
        private readonly AppDbContext _context;

        public SliderController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<SliderVM> sliders = await _context.Sliders.Select(slider => new SliderVM { Id = slider.Id, FirstTitle = slider.FirstTitle, SecondTitle = slider.SecondTitle, Description = slider.Description, Image = slider.Image }).ToListAsync();
            return View(sliders);
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            if (id is null) return BadRequest();
            Slider slider = await _context.Sliders.FirstOrDefaultAsync(m => m.Id == id);
            if (slider is null) return NotFound();
            return View(new SliderDetailVM { FirstTitle = slider.FirstTitle,SecondTitle = slider.SecondTitle, Description = slider.Description, Image = slider.Image });
        }
    }
}
