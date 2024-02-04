using AspnetClient.Pages;
using Microsoft.AspNetCore.Mvc;

namespace AspnetClient.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(new IndexModel());
        }
    }
}
