using System.Linq;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Entities;

namespace DataAccess.Context
{
    public class FantastikContext : IdentityDbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=;Database=FantastikDB;User Id=sa;Password=Wissen2018;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<PostPhoto>().HasKey(pp => new {pp.PostId, pp.PhotoId});
            builder.Entity<PostPhoto>().HasOne(pp => pp.Post).WithMany(p => p.PostPhotos)
                .HasForeignKey(pp => pp.PostId);
            builder.Entity<PostPhoto>().HasOne(pp => pp.Photo).WithMany(p => p.PostPhotos)
                .HasForeignKey(pp => pp.PhotoId);
            foreach (var foreignkey in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                foreignkey.DeleteBehavior = DeleteBehavior.Restrict;
            }
            base.OnModelCreating(builder);
            
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<PostPhoto> PostPhotos { get; set; }
        public DbSet<Status> Statuses { get; set; }

    }
}
