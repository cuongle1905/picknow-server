using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PickNowWeb.Models;

namespace PickNowWeb.DbContexts
{
    public class MyDbContext : DbContext
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Ward> Wards { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Use Fluent API to configure

            // Map entities to tables
            modelBuilder.Entity<Country>().ToTable("country");
            modelBuilder.Entity<Province>().ToTable("province");
            modelBuilder.Entity<District>().ToTable("district");
            modelBuilder.Entity<Ward>().ToTable("ward");

            // Configure Primary Keys
            modelBuilder.Entity<Country>().HasKey(e => e.Id).HasName("PK_Country");
            modelBuilder.Entity<Province>().HasKey(e => e.Id).HasName("PK_Province");
            modelBuilder.Entity<District>().HasKey(e => e.Id).HasName("PK_District");
            modelBuilder.Entity<Ward>().HasKey(e => e.Id).HasName("PK_Ward");

            // Configure indexes
            modelBuilder.Entity<Country>().HasIndex(e => e.Name).IsUnique().HasDatabaseName("name_UNIQUE");
            modelBuilder.Entity<Province>().HasIndex(e => e.Name).IsUnique().HasDatabaseName("name_UNIQUE");
            modelBuilder.Entity<District>().HasIndex(e => e.Name).IsUnique().HasDatabaseName("name_UNIQUE");

            // Configure columns
            modelBuilder.Entity<Country>().Property(e => e.Id).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();
            modelBuilder.Entity<Country>().Property(e => e.Name).HasColumnType("varchar(50)").IsRequired();

            modelBuilder.Entity<Province>().Property(e => e.Id).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();
            modelBuilder.Entity<Province>().Property(e => e.Name).HasColumnType("varchar(50)").IsRequired();
            modelBuilder.Entity<Province>().Property(e => e.Country).HasColumnType("int").IsRequired();

            modelBuilder.Entity<District>().Property(e => e.Id).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();
            modelBuilder.Entity<District>().Property(e => e.Name).HasColumnType("varchar(50)").IsRequired();
            modelBuilder.Entity<District>().Property(e => e.Province).HasColumnType("int").IsRequired();
            modelBuilder.Entity<District>().Property(e => e.Code).HasColumnType("int");

            modelBuilder.Entity<Ward>().Property(e => e.Id).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();
            modelBuilder.Entity<Ward>().Property(e => e.Name).HasColumnType("varchar(50)").IsRequired();
            modelBuilder.Entity<Ward>().Property(e => e.District).HasColumnType("int").IsRequired();
            modelBuilder.Entity<Ward>().Property(e => e.Code).HasColumnType("int");

            // Configure relationships
            modelBuilder.Entity<Province>().HasOne<Country>().WithMany().HasPrincipalKey(c => c.Id).HasForeignKey(p => p.Country).OnDelete(DeleteBehavior.Cascade).HasConstraintName("fk_country");
            modelBuilder.Entity<District>().HasOne<Province>().WithMany().HasPrincipalKey(p => p.Id).HasForeignKey(d => d.Province).OnDelete(DeleteBehavior.Cascade).HasConstraintName("fk_province");
            modelBuilder.Entity<Ward>().HasOne<District>().WithMany().HasPrincipalKey(d => d.Id).HasForeignKey(w => w.District).OnDelete(DeleteBehavior.Cascade).HasConstraintName("fk_district");
        }
    }
}
