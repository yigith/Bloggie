using System.ComponentModel.DataAnnotations;

namespace Bloggie.Data
{
    public class ApplicationUser : IdentityUser
    {
        [Required, MaxLength(30)]
        public string DisplayName { get; set; }

        public List<Post> Posts { get; set; }
    }
}
