using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

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
                if (item.Entity is ISlug)
                {
                    ISlug slugEntity = item.Entity as ISlug;
                    if (slugEntity is Category)
                        SetSlug<Category>(slugEntity);
                    else if (slugEntity is Post)
                        SetSlug<Post>(slugEntity);
                    //GetType().GetMethod("SetSlug", BindingFlags.NonPublic | BindingFlags.Instance)
                    //    .MakeGenericMethod(slugEntity.GetType()).Invoke(this, new object[] { slugEntity });
                }
            }
        }

        private void SetSlug<T>(ISlug entity) where T : class, ISlug
        {
            int counter = 0;
            string slug;
            do
            {
                slug = UrlUtilities.URLFriendly(entity.GetSlugText()) + (counter == 0 ? "" : $"-{counter}");
                counter++;
            } while (Set<T>().Any(x => x.Slug == slug));

            entity.Slug = slug;
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