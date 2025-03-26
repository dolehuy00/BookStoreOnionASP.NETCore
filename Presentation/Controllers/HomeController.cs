using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        /// Basic user
        // Basic user index
        [AllowAnonymous]
        [HttpGet("home")]
        [HttpGet("")]
        public IActionResult UserIndex()
        {
            return View("BasicUser/UserIndex");
        }

        // About us
        [AllowAnonymous]
        [HttpGet("about-us")]
        public IActionResult AboutUs()
        {
            return View("BasicUser/AboutUs");
        }

        // Feedback
        [AllowAnonymous]
        [HttpGet("feedback")]
        public IActionResult Feedback()
        {
            return View("BasicUser/Feedback");
        }

        /// Admin
        // Admin index action
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
