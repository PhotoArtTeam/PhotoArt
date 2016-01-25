﻿namespace PhotoArt.Data
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using Models;
    using System;

    public interface IPhotoArtDbContext
    {
        IDbSet<User> Users { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        void Dispose();

        int SaveChanges();
    }
}
