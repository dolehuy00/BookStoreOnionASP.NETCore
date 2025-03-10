using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        [AllowAnonymous]
        [HttpGet("home")]
        [HttpGet("")]
        public IActionResult UserIndex()
        {
            return View("User/UserIndex");
        }

        [Authorize(
            AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme,
            Policy = "AdminOnly")
        ]
        [HttpGet("/manage")]
        public IActionResult AdminIndex()
        {
            return View("Admin/AdminIndex");
        }
    }
}
