namespace Bloggie.Data
{
    public static class ApplicationDbContextSeed
    {
        public async static Task SeedAsync(ApplicationDbContext db, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            await db.Database.MigrateAsync();

            var adminEmail = "admin@example.com";
            var adminPass = "P@ssword1";
            var adminRole = "Administrator";

            var cat1 = new Category() { Name = "Sample Category 1" };
            var cat2 = new Category() { Name = "Sample Category 2" };
            var post1 = new Post()
            {
                Title = "Sample Post 1",
                Content = "<p>Tincidunt integer eu augue augue nunc elit dolor, luctus placerat scelerisque euismod, iaculis eu lacus nunc mi elit, vehicula ut laoreet ac, aliquam sit amet justo nunc tempor, metus vel.</p>",
                Category = cat1
            };
            var post2 = new Post()
            {
                Title = "Sample Post 2",
                Content = "<p>Placerat suscipit, orci nisl iaculis eros, a tincidunt nisi odio eget lorem nulla condimentum tempor mattis ut vitae feugiat augue cras ut metus a risus iaculis scelerisque eu ac ante.</p>",
                Category = cat1
            };
            var post3 = new Post()
            {
                Title = "Sample Post 3",
                Content = "<p>Fusce non varius purus aenean nec magna felis fusce vestibulum velit mollis odio sollicitudin lacinia aliquam posuere, sapien elementum lobortis tincidunt, turpis dui ornare nisl, sollicitudin interdum turpis nunc eget.</p>",
                Category = cat2
            };
            var post4 = new Post()
            {
                Title = "Sample Post 4",
                Content = "<p>Sem nulla eu ultricies orci praesent id augue nec lorem pretium congue sit amet ac nunc fusce iaculis lorem eu diam hendrerit at mattis purus dignissim vivamus mauris tellus, fringilla.</p>",
                Category = cat2
            };

            if (!await roleManager.RoleExistsAsync(adminRole))
            {
                await roleManager.CreateAsync(new IdentityRole(adminRole));
            }

            if (!userManager.Users.Any(x => x.UserName == adminEmail))
            {
                var adminUser = new ApplicationUser()
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    DisplayName = "Admin User",
                    EmailConfirmed = true,
                    Posts = new List<Post>() { post1, post2, post3, post4 }
                };
                await userManager.CreateAsync(adminUser, adminPass);
                await userManager.AddToRoleAsync(adminUser, adminRole);
            }
        }

        public async static Task SeedDataAsync(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                await SeedAsync(db, userManager, roleManager);
            }
        }
    }
}
