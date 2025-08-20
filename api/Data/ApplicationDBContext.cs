using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Helpers;
using api.Models;
using Domain.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class ApplicationDBContext : IdentityDbContext<AppUser>
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions)
        : base(dbContextOptions)
        {

        }

        public DbSet<ProductCategory> ProductCategories { get; set; }

        public DbSet<ProductUnit> ProductUnits { get; set; }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AppUser>()
                .Property(u => u.Role)
                .HasConversion<string>();

            builder.Entity<AppUser>()
                .Property(u => u.PIN)
                .HasMaxLength(44)
                .IsRequired();

            builder.Entity<AppUser>()
                .Property(u => u.UserName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Entity<IdentityRole>().HasData(
                new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Name = "Manager", NormalizedName = "MANAGER" }
            );

            builder.Entity<ProductCategory>(entity =>
                {
                    entity.ToTable("ProductCategories");

                    entity.HasKey(c => c.Id);

                    entity.Property(c => c.Name)
                    .IsRequired()
                    .HasMaxLength(50);
                });

            builder.Entity<ProductUnit>(entity =>
                {
                    entity.ToTable("ProductUnits");

                    entity.HasKey(u => u.Id);

                    entity.Property(u => u.Name)
                    .IsRequired()
                    .HasMaxLength(50);
                });

            builder.Entity<Product>(entity =>
                {
                    entity.Property(p => p.UnitPrice).HasColumnType("decimal(18,2)");
                    entity.HasOne(p => p.ProductCategory)
                        .WithMany()
                        .HasForeignKey(p => p.ProductCategoryId)
                        .OnDelete(DeleteBehavior.Restrict);

                    entity.HasOne(p => p.ProductUnit)
                        .WithMany()
                        .HasForeignKey(p => p.ProductUnitId)
                        .OnDelete(DeleteBehavior.Restrict);
                });
        }

    }
}