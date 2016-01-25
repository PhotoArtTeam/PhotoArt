namespace PhotoArt.Data

{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Contracts;
    using Migrations;

    // using Migrations;

    public class PhotoArtDbContext : IdentityDbContext<User>, IPhotoArtDbContext
    {
        public PhotoArtDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<PhotoArtDbContext, Configuration>());
        }

        public  IDbSet<Portfolio> Portfolios { get; set; }

        public  IDbSet<Album> Albums { get; set; }

        public  IDbSet<Image> Images { get; set; }

        public  IDbSet<Comment> Comments { get; set; }

        public  IDbSet<Technology> Technologies { get; set; }

        public  IDbSet<Category> Categories { get; set; }

        public  IDbSet<TechnologyType> TechnologyTypes { get; set; }

        public static PhotoArtDbContext Create()
        {
            return new PhotoArtDbContext();
        }

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            this.ApplyDeletableEntityRules();
            return base.SaveChanges();
        }

        private void ApplyAuditInfoRules()
        {
            // Approach via @julielerman: http://bit.ly/123661P
            foreach (var entry in
                this.ChangeTracker.Entries()
                    .Where(
                        e =>
                        e.Entity is IAuditInfo && ((e.State == EntityState.Added) || (e.State == EntityState.Modified))))
            {
                var entity = (IAuditInfo)entry.Entity;

                if (entry.State == EntityState.Added)
                {
                    if (!entity.PreserveCreatedOn)
                    {
                        entity.CreatedOn = DateTime.Now;
                    }
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }

        private void ApplyDeletableEntityRules()
        {
            // Approach via @julielerman: http://bit.ly/123661P
            foreach (
                var entry in
                    this.ChangeTracker.Entries()
                        .Where(e => e.Entity is IDeletableEntity && (e.State == EntityState.Deleted)))
            {
                var entity = (IDeletableEntity)entry.Entity;

                entity.DeletedOn = DateTime.Now;
                entity.IsDeleted = true;
                entry.State = EntityState.Modified;
            }
        }

    }
}
