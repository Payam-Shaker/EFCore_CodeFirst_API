using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BicyleStoreAPI.Models
{
    public partial class BicycleStoreContext : DbContext
    {
        public BicycleStoreContext()
        {
        }

        public BicycleStoreContext(DbContextOptions<BicycleStoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bicycle> Bicycles { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<CustomerInfo> CustomerInfos { get; set; }
        public virtual DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-PH8D08N\\SQLEXPRESS;initial catalog=BicycleStore_Db;Integrated Security=True;ConnectRetryCount=0");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Finnish_Swedish_CI_AS");

            modelBuilder.Entity<Bicycle>(entity =>
            {
                entity.HasKey(e => e.ProductId)
                    .HasName("PK_bicycles");

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.Bicycles)
                    .HasForeignKey(d => d.BrandId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_brand_id");
               

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Bicycles)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_catego");
            });

            modelBuilder.Entity<CustomerInfo>(entity =>
            {
                entity.HasKey(e => e.CustomerId)
                    .HasName("PK_customer");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.Cost).HasComputedColumnSql("([quantity]*[price])", false);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__orders__customer__440B1D61");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__orders__product___4316F928");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
