using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace basura.Models
{
    public partial class gestoresdbContext : DbContext
    {
        public gestoresdbContext()
        {
        }

        public gestoresdbContext(DbContextOptions<gestoresdbContext> options)
            : base(options)
        {
        }

            public virtual DbSet<Customer> Customers { get; set; } = null!;
            public virtual DbSet<DetailInvoice> DetailInvoices { get; set; } = null!;
            public virtual DbSet<Invoice> Invoices { get; set; } = null!;
            public virtual DbSet<Product> Products { get; set; } = null!;
            public virtual DbSet<Provider> Providers { get; set; } = null!;

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                if (!optionsBuilder.IsConfigured)
                {
    #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                    optionsBuilder.UseSqlServer("Data Source= gestoresdb.database.windows.net,1433;Initial Catalog= gestoresdb;User Id= gestoresadmin;Password= Abc.123456;MultipleActiveResultSets=True");
                }
            }

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
