using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class UserProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
