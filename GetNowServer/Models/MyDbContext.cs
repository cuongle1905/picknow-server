using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace GetNowServer.Models
{
    public partial class MyDbContext : DbContext
    {

        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Color> Colors { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<CompanyLogo> CompanyLogos { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<District> Districts { get; set; }
        public virtual DbSet<Driver> Drivers { get; set; }
        public virtual DbSet<ImageInfo> ImageInfos { get; set; }
        public virtual DbSet<Origin> Origins { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductAttribute> ProductAttributes { get; set; }
        public virtual DbSet<Province> Provinces { get; set; }
        public virtual DbSet<Size> Sizes { get; set; }
        public virtual DbSet<Store> Stores { get; set; }
        public virtual DbSet<StoreGroup> StoreGroups { get; set; }
        public virtual DbSet<StoreProduct> StoreProducts { get; set; }
        public virtual DbSet<StoreProductGroup> StoreProductGroups { get; set; }
        public virtual DbSet<StoreProductView> StoreProductViews { get; set; }
        public virtual DbSet<StringObject> StringObjects { get; set; }
        public virtual DbSet<Unit> Units { get; set; }
        public virtual DbSet<Ward> Wards { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;port=3306;database=picknow;user=root;password=root;persist security info=False;connect timeout=300", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.25-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.ToTable("brand");

                entity.HasIndex(e => e.Name, "uniq_brand_name")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name")
                    .UseCollation("utf8_bin")
                    .HasCharSet("utf8");

                entity.Property(e => e.Parent).HasColumnName("parent");
            });

            modelBuilder.Entity<Color>(entity =>
            {
                entity.ToTable("color");

                entity.HasIndex(e => e.Name, "uniq_color_name")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("name")
                    .UseCollation("utf8_bin")
                    .HasCharSet("utf8");
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.ToTable("company");

                entity.HasIndex(e => e.Logo, "fk_company_logo_idx");

                entity.HasIndex(e => e.Name, "name_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .HasColumnName("email");

                entity.Property(e => e.Logo).HasColumnName("logo");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("name")
                    .UseCollation("utf8_bin")
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

                entity.HasOne(d => d.LogoNavigation)
                    .WithMany(p => p.Companies)
                    .HasForeignKey(d => d.Logo)
                    .HasConstraintName("fk_company_logo");
            });

            modelBuilder.Entity<CompanyLogo>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("company_logo");

                entity.Property(e => e.CompanyId).HasColumnName("company_id");

                entity.Property(e => e.FileName)
                    .HasMaxLength(45)
                    .HasColumnName("file_name");

                entity.Property(e => e.Logo).HasColumnName("logo");
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
                    .UseCollation("utf8_bin")
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
                    .UseCollation("utf8_bin")
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

            modelBuilder.Entity<ImageInfo>(entity =>
            {
                entity.ToTable("image_info");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.FileName)
                    .HasMaxLength(45)
                    .HasColumnName("file_name");
            });

            modelBuilder.Entity<Origin>(entity =>
            {
                entity.ToTable("origin");

                entity.HasIndex(e => e.Name, "uniq_origin_name")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("name")
                    .UseCollation("utf8_bin")
                    .HasCharSet("utf8");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("product");

                entity.HasIndex(e => e.Brand, "fk_product_brand_idx");

                entity.HasIndex(e => e.Color, "fk_product_color_idx");

                entity.HasIndex(e => e.Image, "fk_product_image_idx");

                entity.HasIndex(e => e.Origin, "fk_product_origin_idx");

                entity.HasIndex(e => e.Size, "fk_product_size_idx");

                entity.HasIndex(e => e.Unit, "fk_product_unit_idx");

                entity.HasIndex(e => e.Code, "idx_product_code");

                entity.HasIndex(e => e.Name, "uniq_product_name")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Brand).HasColumnName("brand");

                entity.Property(e => e.Code)
                    .HasMaxLength(45)
                    .HasColumnName("code");

                entity.Property(e => e.Color).HasColumnName("color");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("description")
                    .UseCollation("utf8_bin")
                    .HasCharSet("utf8");

                entity.Property(e => e.Image).HasColumnName("image");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.Origin)
                    .HasColumnName("origin")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Size).HasColumnName("size");

                entity.Property(e => e.Unit).HasColumnName("unit");

                entity.HasOne(d => d.BrandNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.Brand)
                    .HasConstraintName("fk_product_brand");

                entity.HasOne(d => d.ColorNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.Color)
                    .HasConstraintName("fk_product_color");

                entity.HasOne(d => d.ImageNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.Image)
                    .HasConstraintName("fk_product_image");

                entity.HasOne(d => d.OriginNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.Origin)
                    .HasConstraintName("fk_product_origin");

                entity.HasOne(d => d.SizeNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.Size)
                    .HasConstraintName("fk_product_size");

                entity.HasOne(d => d.UnitNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.Unit)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_product_unit");
            });

            modelBuilder.Entity<ProductAttribute>(entity =>
            {
                entity.ToTable("product_attribute");

                entity.HasIndex(e => e.Name, "uniq_product_attribute_name")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("name")
                    .UseCollation("utf8_bin")
                    .HasCharSet("utf8");
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
                    .UseCollation("utf8_bin")
                    .HasCharSet("utf8");

                entity.HasOne(d => d.CountryNavigation)
                    .WithMany(p => p.Provinces)
                    .HasForeignKey(d => d.Country)
                    .HasConstraintName("fk_country");
            });

            modelBuilder.Entity<Size>(entity =>
            {
                entity.ToTable("size");

                entity.HasIndex(e => e.Name, "uniq_size_name")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("name")
                    .UseCollation("utf8_bin")
                    .HasCharSet("utf8");

                entity.Property(e => e.Volumn).HasColumnName("volumn");

                entity.Property(e => e.Weight).HasColumnName("weight");
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.ToTable("store");

                entity.HasIndex(e => e.District, "fk_district_idx");

                entity.HasIndex(e => e.Province, "fk_province_idx");

                entity.HasIndex(e => e.StoreGroup, "fk_store_store_group_idx");

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

                entity.Property(e => e.ContactName)
                    .HasMaxLength(45)
                    .HasColumnName("contact_name")
                    .UseCollation("utf8_bin")
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
                    .HasColumnName("name")
                    .UseCollation("utf8_bin")
                    .HasCharSet("utf8");

                entity.Property(e => e.Province).HasColumnName("province");

                entity.Property(e => e.StoreGroup).HasColumnName("store_group");

                entity.Property(e => e.Ward).HasColumnName("ward");

                entity.Property(e => e.Website)
                    .HasMaxLength(100)
                    .HasColumnName("website");

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

                entity.HasOne(d => d.StoreGroupNavigation)
                    .WithMany(p => p.Stores)
                    .HasForeignKey(d => d.StoreGroup)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_store_store_group");

                entity.HasOne(d => d.WardNavigation)
                    .WithMany(p => p.Stores)
                    .HasForeignKey(d => d.Ward)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_store_ward");
            });

            modelBuilder.Entity<StoreGroup>(entity =>
            {
                entity.ToTable("store_group");

                entity.HasIndex(e => e.Company, "fk_store_group_company_idx");

                entity.HasIndex(e => e.Name, "uniq_store_group_name")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Company).HasColumnName("company");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("name")
                    .UseCollation("utf8_bin")
                    .HasCharSet("utf8");

                entity.HasOne(d => d.CompanyNavigation)
                    .WithMany(p => p.StoreGroups)
                    .HasForeignKey(d => d.Company)
                    .HasConstraintName("fk_store_group_company");
            });

            modelBuilder.Entity<StoreProduct>(entity =>
            {
                entity.HasKey(e => new { e.StoreProductGroup, e.Product })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("store_product");

                entity.HasIndex(e => e.Product, "fk_store_product_product_idx");

                entity.Property(e => e.StoreProductGroup).HasColumnName("store_product_group");

                entity.Property(e => e.Product).HasColumnName("product");

                entity.Property(e => e.Price)
                    .HasPrecision(10)
                    .HasColumnName("price");

                entity.HasOne(d => d.ProductNavigation)
                    .WithMany(p => p.StoreProducts)
                    .HasForeignKey(d => d.Product)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_store_product_product");

                entity.HasOne(d => d.StoreProductGroupNavigation)
                    .WithMany(p => p.StoreProducts)
                    .HasForeignKey(d => d.StoreProductGroup)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_store_product_store_product_group");
            });

            modelBuilder.Entity<StoreProductGroup>(entity =>
            {
                entity.ToTable("store_product_group");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("name")
                    .UseCollation("utf8_bin")
                    .HasCharSet("utf8");

                entity.Property(e => e.Parent).HasColumnName("parent");

                entity.Property(e => e.StoreGroup).HasColumnName("store_group");
            });

            modelBuilder.Entity<StoreProductView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("store_product_view");

                entity.Property(e => e.Brand).HasColumnName("brand");

                entity.Property(e => e.Code)
                    .HasMaxLength(45)
                    .HasColumnName("code");

                entity.Property(e => e.Color).HasColumnName("color");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("description")
                    .UseCollation("utf8_bin")
                    .HasCharSet("utf8");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Image).HasColumnName("image");

                entity.Property(e => e.ImageFile)
                    .HasMaxLength(45)
                    .HasColumnName("image_file");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.Origin)
                    .HasColumnName("origin")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Price)
                    .HasPrecision(10)
                    .HasColumnName("price");

                entity.Property(e => e.Size).HasColumnName("size");

                entity.Property(e => e.StoreGroup).HasColumnName("store_group");

                entity.Property(e => e.StoreProductGroup).HasColumnName("store_product_group");

                entity.Property(e => e.StoreProductGroups)
                    .HasMaxLength(100)
                    .HasColumnName("store_product_groups");

                entity.Property(e => e.Unit).HasColumnName("unit");
            });

            modelBuilder.Entity<StringObject>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("string_object");

                entity.Property(e => e.Id)
                    .HasMaxLength(1000)
                    .HasColumnName("id")
                    .UseCollation("utf8_bin")
                    .HasCharSet("utf8");
            });

            modelBuilder.Entity<Unit>(entity =>
            {
                entity.ToTable("unit");

                entity.HasIndex(e => e.Name, "uniq_unit_name")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.BaseUnit)
                    .HasColumnName("base_unit")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Exchange)
                    .HasColumnName("exchange")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("name")
                    .UseCollation("utf8_bin")
                    .HasCharSet("utf8");
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
                    .UseCollation("utf8_bin")
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
