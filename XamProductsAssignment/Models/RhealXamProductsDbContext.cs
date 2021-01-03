using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace XamProductsAssignment.Models
{
    public partial class RhealXamProductsDbContext : DbContext
    {
        public RhealXamProductsDbContext()
        {
        }

        public RhealXamProductsDbContext(DbContextOptions<RhealXamProductsDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Manufacturer> Manufacturers { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                //optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=RhealXamProductsDb;Integrated Security=SSPI;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.CategoryRowId)
                    .HasName("PK__Categori__8C55F0903CD8DDF1");

                entity.Property(e => e.CategoryRowId).HasColumnName("CategoryRowID");

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Manufacturer>(entity =>
            {
                entity.HasKey(e => e.ManufacturerRowId)
                    .HasName("PK__Manufact__1F6177B46690341A");

                entity.Property(e => e.ManufacturerRowId).HasColumnName("ManufacturerRowID");

                entity.Property(e => e.ManufacturerName)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.ProductRowId)
                    .HasName("PK__Products__2F7036E1C8E328BB");

                entity.Property(e => e.ProductDescription)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.ProductId)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ProductName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.ProductAddedByUserNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ProductAddedByUser)
                    .HasConstraintName("FK__Products__Produc__2C3393D0");

                entity.HasOne(d => d.ProductCategoryNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ProductCategory)
                    .HasConstraintName("FK__Products__Produc__2A4B4B5E");

                entity.HasOne(d => d.ProductManufacturerNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ProductManufacturer)
                    .HasConstraintName("FK__Products__Produc__2B3F6F97");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserRowId)
                    .HasName("PK__Users__82B35BD95B774C88");

                entity.Property(e => e.UserName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserPassword)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
