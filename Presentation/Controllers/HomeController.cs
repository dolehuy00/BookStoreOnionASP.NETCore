using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public IActionResult UserIndex()
        {
            return View();
        }

        [Authorize(
            AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme,
            Policy = "AdminOnly")
        ]
        public IActionResult AdminIndex()
        {
            return View();
        }
    }
}
