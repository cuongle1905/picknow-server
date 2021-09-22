using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace PickNowWeb.Models
{
    public partial class MyDbContext : DbContext
    {

        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<District> Districts { get; set; }
        public virtual DbSet<Driver> Drivers { get; set; }
        public virtual DbSet<Province> Provinces { get; set; }
        public virtual DbSet<Store> Stores { get; set; }
        public virtual DbSet<Ward> Wards { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=localhost;port=3306;database=picknow;user=root;password=root;persist security info=False;connect timeout=300", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.25-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            modelBuilder.Entity<Company>(entity =>
            {
                entity.ToTable("company");

                entity.HasIndex(e => e.Name, "name_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .HasColumnName("email");

                entity.Property(e => e.Logo)
                    .HasMaxLength(100)
                    .HasColumnName("logo");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("name")
                    .UseCollation("utf8_unicode_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Phone)
                    .HasMaxLength(30)
                    .HasColumnName("phone");

                entity.Property(e => e.Phone2)
                    .HasMaxLength(30)
                    .HasColumnName("phone2");

                entity.Property(e => e.TaxCode)
                    .HasMaxLength(20)
                    .HasColumnName("tax_code");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("country");

                entity.HasIndex(e => e.Name, "name_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name")
                    .UseCollation("utf8_unicode_ci")
                    .HasCharSet("utf8");
            });

            modelBuilder.Entity<District>(entity =>
            {
                entity.ToTable("district");

                entity.HasIndex(e => e.Province, "fk_province_idx");

                entity.HasIndex(e => e.Name, "name_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Code).HasColumnName("code");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name")
                    .UseCollation("utf8_unicode_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Province).HasColumnName("province");

                entity.HasOne(d => d.ProvinceNavigation)
                    .WithMany(p => p.Districts)
                    .HasForeignKey(d => d.Province)
                    .HasConstraintName("fk_province");
            });

            modelBuilder.Entity<Driver>(entity =>
            {
                entity.ToTable("driver");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("address")
                    .UseCollation("utf8_unicode_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .HasColumnName("description")
                    .UseCollation("utf8_unicode_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("dob");

                entity.Property(e => e.Email)
                    .HasMaxLength(45)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("first_name")
                    .UseCollation("utf8_unicode_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("last_name");

                entity.Property(e => e.MidName)
                    .HasMaxLength(45)
                    .HasColumnName("mid_name");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("phone");

                entity.Property(e => e.Photo)
                    .HasMaxLength(45)
                    .HasColumnName("photo");

                entity.Property(e => e.Ward).HasColumnName("ward");
            });

            modelBuilder.Entity<Province>(entity =>
            {
                entity.ToTable("province");

                entity.HasIndex(e => e.Country, "fk_country_idx");

                entity.HasIndex(e => e.Name, "name_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Country).HasColumnName("country");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name")
                    .UseCollation("utf8_unicode_ci")
                    .HasCharSet("utf8");

                entity.HasOne(d => d.CountryNavigation)
                    .WithMany(p => p.Provinces)
                    .HasForeignKey(d => d.Country)
                    .HasConstraintName("fk_country");
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.ToTable("store");

                entity.HasIndex(e => e.Company, "fk_company_idx");

                entity.HasIndex(e => e.District, "fk_district_idx");

                entity.HasIndex(e => e.Province, "fk_province_idx");

                entity.HasIndex(e => e.Ward, "fk_ward_idx");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("address")
                    .UseCollation("utf8_unicode_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Company).HasColumnName("company");

                entity.Property(e => e.ContactName)
                    .HasMaxLength(45)
                    .HasColumnName("contact_name")
                    .UseCollation("utf8_unicode_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.ContactPhone)
                    .HasMaxLength(20)
                    .HasColumnName("contact_phone");

                entity.Property(e => e.ContactPhone2)
                    .HasMaxLength(20)
                    .HasColumnName("contact_phone2");

                entity.Property(e => e.District).HasColumnName("district");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.Province).HasColumnName("province");

                entity.Property(e => e.Ward).HasColumnName("ward");

                entity.Property(e => e.Website)
                    .HasMaxLength(100)
                    .HasColumnName("website");

                entity.HasOne(d => d.CompanyNavigation)
                    .WithMany(p => p.Stores)
                    .HasForeignKey(d => d.Company)
                    .HasConstraintName("fk_store_company");

                entity.HasOne(d => d.DistrictNavigation)
                    .WithMany(p => p.Stores)
                    .HasForeignKey(d => d.District)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_store_district");

                entity.HasOne(d => d.ProvinceNavigation)
                    .WithMany(p => p.Stores)
                    .HasForeignKey(d => d.Province)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_store_province");

                entity.HasOne(d => d.WardNavigation)
                    .WithMany(p => p.Stores)
                    .HasForeignKey(d => d.Ward)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_store_ward");
            });

            modelBuilder.Entity<Ward>(entity =>
            {
                entity.ToTable("ward");

                entity.HasIndex(e => e.District, "fk_district_idx");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Code).HasColumnName("code");

                entity.Property(e => e.District).HasColumnName("district");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("name")
                    .UseCollation("utf8_unicode_ci")
                    .HasCharSet("utf8");

                entity.HasOne(d => d.DistrictNavigation)
                    .WithMany(p => p.Wards)
                    .HasForeignKey(d => d.District)
                    .HasConstraintName("fk_district");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
