using System.Linq;
using DataAccess.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Entities;

namespace DataAccess.Context
{
    public class FantastikContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=;Database=FantastikRehberDB;User Id=sa;Password=Wissen2018;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<ProductionPerformer>()
                .HasKey(bc => new { bc.PerformerId, bc.ProductionId });
            builder.Entity<ProductionPerformer>()
                .HasOne(bc => bc.Performer)
                .WithMany(b => b.ProductionPerformers)
                .HasForeignKey(bc => bc.PerformerId);
            builder.Entity<ProductionPerformer>()
                .HasOne(bc => bc.Production)
                .WithMany(c => c.ProductionPerformers)
                .HasForeignKey(bc => bc.ProductionId);
            foreach (var foreignkey in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                foreignkey.DeleteBehavior = DeleteBehavior.Restrict;
            }
            base.OnModelCreating(builder);


            builder.Entity<Status>().HasData(
                new Status { StatusId = 1, Title = "Yayında" },
                new Status { StatusId = 2, Title = "Taslak" },
                new Status { StatusId = 3, Title = "Silinmiş" });


            builder.Entity<ProductionType>().HasData(
                new ProductionType { ProductionTypeId = 1, Title = "Film" },
                new ProductionType { ProductionTypeId = 2, Title = "Dizi" });

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<ProductionType> ProductionTypes { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Production> Productions { get; set; }
        public DbSet<Performer> Performers { get; set; }

    }
}
