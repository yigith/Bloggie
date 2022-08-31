using Bloggie.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Bloggie.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        [Route("")]
        [Route("c/{slug}")]
        public IActionResult Index(string slug, int pid = 1)
        {
            var posts = _db.Posts
                    .Include(x => x.Author)
                    .Where(x => slug == null || x.Category.Slug == slug)
                    .Where(x => !x.IsDraft);
            int postCount = posts.Count();
            int pageCount = (int)Math.Ceiling((double)postCount / Constants.POSTS_PER_PAGE);

            var vm = new HomeViewModel()
            {
                Categories = _db.Categories.OrderBy(x => x.Name).ToList(),
                Posts = posts
                    .OrderByDescending(x => x.CreatedTime)
                    .Skip((pid - 1) * Constants.POSTS_PER_PAGE)
                    .Take(Constants.POSTS_PER_PAGE)
                    .ToList(),
                Page = pid,
                HasNewer = pid > 1,
                HasOlder = pid < pageCount,
            };
            return View(vm);
        }

        [Route("p/{slug}")]
        public IActionResult Post(string slug)
        {
            var post = _db.Posts
                .Include(x => x.Author)
                .Where(x => !x.IsDraft)
                .FirstOrDefault(x => x.Slug == slug);

            if (post == null) return NotFound();

            return View(post);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}