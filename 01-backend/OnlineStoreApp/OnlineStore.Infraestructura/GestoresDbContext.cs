using Microsoft.EntityFrameworkCore;
using OlineStore.Dto.Models;

namespace OnlineStore.Infraestructura
{
    public partial class GestoresDbContext:DbContext
    {
        public GestoresDbContext()
        {
                
        }

        public GestoresDbContext(DbContextOptions<GestoresDbContext>options):base(options)
        {
                
        }

        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<DetailInvoice> DetailInvoices { get; set; } = null!;
        public virtual DbSet<Invoice> Invoices { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<Provider> Providers { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.IdCustomer);

                entity.ToTable("Customer");

                entity.Property(e => e.Document).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.Mail).HasMaxLength(50);

                entity.Property(e => e.NameCustomer).HasMaxLength(50);

                entity.Property(e => e.PhoneNumber).HasMaxLength(50);
            });

            modelBuilder.Entity<DetailInvoice>(entity =>
            {
                entity.HasKey(e => e.IdDetail);

                entity.ToTable("DetailInvoice");

                entity.Property(e => e.Total).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.IdInvoiceNavigation)
                    .WithMany(p => p.DetailInvoices)
                    .HasForeignKey(d => d.IdInvoice)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DetailInvoice_Invoice");

                entity.HasOne(d => d.IdProductNavigation)
                    .WithMany(p => p.DetailInvoices)
                    .HasForeignKey(d => d.IdProduct)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DetailInvoice_Product");
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.HasKey(e => e.IdInvoice);

                entity.ToTable("Invoice");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.SubTotal).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.IdCustomerNavigation)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.IdCustomer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Invoice_Customer");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.IdProduct);

                entity.ToTable("Product");

                entity.Property(e => e.DateOfExpery).HasColumnType("date");

                entity.Property(e => e.NameProduct).HasMaxLength(50);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.IdProviderNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.IdProvider)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_Provider");
            });

            modelBuilder.Entity<Provider>(entity =>
            {
                entity.HasKey(e => e.IdProvider);

                entity.ToTable("Provider");

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Nit).HasMaxLength(50);

                entity.Property(e => e.PhoneNumber).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

