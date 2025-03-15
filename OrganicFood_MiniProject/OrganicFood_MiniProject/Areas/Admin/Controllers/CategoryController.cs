using Microsoft.AspNetCore.Mvc;

namespace OrganicFood_MiniProject.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
