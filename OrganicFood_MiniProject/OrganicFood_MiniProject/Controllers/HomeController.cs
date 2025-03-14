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
                Image = slider.Image,
                SliderImage = image?.BackgroundImage
            }).ToList();


            IEnumerable<FreshFruit> freshFruits = await _context.FreshFruits.ToListAsync();
            var freshFruitVM = freshFruits.Select(freshFruit => new FreshFruitVM
            {
                Title = freshFruit.Title,
                Img = freshFruit.Img,
            });


            IEnumerable<SpecialSlider> specialSliders = await _context.SpecialSliders.ToListAsync();
            var specialSliderVM = specialSliders.Select(specialSlider => new SpecialSliderVM
            {
                FirstText = specialSlider.FirstText,
                SecondText = specialSlider.SecondText,
                ThirdText = specialSlider.ThirdText,
                Name = specialSlider.Name,
                Price = specialSlider.Price,
                DiscountedPrice = specialSlider.DiscountedPrice,
                Img = specialSlider.Img,
            });


            IEnumerable<Product> products = await _context.Products
                                                          .Include(m => m.Category)
                                                          .Include(m => m.ProductImages)
                                                          .Include(m => m.ProductDiscounts)
                                                          .ThenInclude(pd => pd.Discount)
                                                          .ToListAsync();
            var productVM = products.Select(product => new ProductVM
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                ProductImages = product.ProductImages.Select(image => new ProductImageVM
                {
                    Name = image.Name,
                    IsMain = image.IsMain,
                }).ToList(),
                CategoryId = product.CategoryId,
                Category = product.Category,
                DiscountedPrice = product.ProductDiscounts.Any()
                                  ? product.Price - (product.ProductDiscounts.Sum(pd => pd.Discount.DiscountPercentage) * product.Price / 100)
                                  : product.Price
            });


            IEnumerable<Category> categories = await _context.Categories
                                                             .Include(c => c.Products)
                                                             .ThenInclude(p => p.ProductImages)
                                                             .ToListAsync();

            var categoryVM = categories.Select(category => new CategoryVM
            {
                Id = category.Id,
                Name = category.Name,
                Image = category.Image
            }).ToList();


            Advertisement advertisement = await _context.Advertisements.FirstOrDefaultAsync();
            var advertisementVM = new AdvertisementVM
            {
                BackgroundImage = advertisement.BackgroundImage,
                FirstImage = advertisement.FirstImage,
                SecondImage = advertisement.SecondImage,
                ThirdImage = advertisement.ThirdImage,
                FourthImage = advertisement.FourthImage
            };


            Promotion promotion = await _context.Promotions.FirstOrDefaultAsync();
            var promotionVM = new PromotionVM
            {
                Image = promotion.Image,
                Title = promotion.Title,
                Description = promotion.Description,
            };


            var homeVM = new HomeVM
            {
                Sliders = sliderVM,
                SliderImage = image,
                FreshFruits = freshFruitVM,
                SpecialSliders = specialSliderVM,
                Products = productVM,
                Categories = categoryVM,
                Advertisement = advertisementVM,
                Promotion = promotionVM,
            };

            return View(homeVM);
        }

    }
}
           

