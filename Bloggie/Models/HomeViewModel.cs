namespace Bloggie.Models
{
    public class HomeViewModel
    {
        public List<Category> Categories { get; set; }

        public List<Post> Posts { get; set; }

        public bool HasNewer { get; set; }

        public bool HasOlder { get; set; }

        public int Page { get; set; }
    }
}
