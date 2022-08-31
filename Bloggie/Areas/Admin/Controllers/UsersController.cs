using Microsoft.AspNetCore.Mvc;

namespace Bloggie.Areas.Admin.Controllers
{
    public class UsersController : AdminBaseController
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UsersController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View(_userManager.Users.ToList());
        }
    }
}
