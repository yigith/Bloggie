using Microsoft.AspNetCore.Mvc;

namespace Bloggie.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Administrator")]
    public abstract class AdminBaseController : Controller
    {
    }
}
