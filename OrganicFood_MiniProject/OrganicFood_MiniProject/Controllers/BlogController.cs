using Microsoft.AspNetCore.Mvc;

namespace OrganicFood_MiniProject.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
