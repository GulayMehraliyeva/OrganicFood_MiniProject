using Microsoft.AspNetCore.Mvc;

namespace OrganicFood_MiniProject.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
