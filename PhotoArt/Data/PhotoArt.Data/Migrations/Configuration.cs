namespace PhotoArt.Data.Migrations
{
    using System.Data.Entity.Migrations;

    using Microsoft.AspNet.Identity.EntityFramework;

    using EnumTablesHelper;
    using Models;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PhotoArt.Data.PhotoArtDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(PhotoArt.Data.PhotoArtDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.Roles.AddOrUpdate(
              p => p.Name,
              new IdentityRole { Name = "Admin" },
              new IdentityRole { Name = "User" }
            );

            if (context.TechnologyTypes.Count() == 0)
            {
                EnumTablesHelper.SeedEnumData<TechnologyType, TechnologyTypeEnum>(context.TechnologyTypes);
            }
            if (!context.Users.Where(u => u.UserName == "admin@admin.com").Any())
            {
                var admin = new User
                {
                    UserName = "admin@admin.com",
                    Email = "admin@admin.com",
                    PasswordHash = "AJ6xY/N9kWRShbJYh8QE5fIt5Yg5IeyTFBnJ9RXAdIXUo9hiqxtVWRiYJ0XyUHVDbg==",
                    SecurityStamp = "59bcf0ca-0367-4397-b3c1-af413e479e0c",
                    LockoutEnabled = true,
                };

                context.Users.Add(admin);

                var role = context.Roles.Where(r => r.Name == "Admin").FirstOrDefault();
                var adminRole = new IdentityUserRole
                {
                    RoleId = role.Id
                };

                admin.Roles.Add(adminRole);
                context.SaveChanges();
            }
        }
    }
}
