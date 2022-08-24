using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Bloggie.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
