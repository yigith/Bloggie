using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bloggie.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Post> Posts { get; set; }

        private void GenerateSlugs()
        {
            foreach (var item in ChangeTracker.Entries())
            {
                if (item.Entity is Category)
                {
                    var cat = (Category)item.Entity;
                    cat.Slug = UrlUtilities.URLFriendly(cat.Name);
                } 
                else if (item.Entity is Post)
                {
                    var post = (Post)item.Entity;
                    post.Slug = UrlUtilities.URLFriendly(post.Title);
                }
            }
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            GenerateSlugs();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            GenerateSlugs();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
    }
}