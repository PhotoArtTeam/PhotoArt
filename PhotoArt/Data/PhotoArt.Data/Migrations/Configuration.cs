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
        }
    }
}
