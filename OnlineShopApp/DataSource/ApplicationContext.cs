using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OnlineShopApp.Models;

namespace OnlineShopApp.DataSource;

public partial class ApplicationContext : DbContext
{
    public ApplicationContext()
    {
    }

    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Provider> Providers { get; set; }

    public virtual DbSet<Store> Stores { get; set; }

    public virtual DbSet<TypesProduct> TypesProducts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-5QT96PO;Initial Catalog=onlineShop;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.IdCategory).HasName("PK__CATEGORI__EC9B18B766163D6A");

            entity.ToTable("CATEGORIES");

            entity.Property(e => e.IdCategory).HasColumnName("ID_CATEGORY");
            entity.Property(e => e.NameCategory)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NAME_CATEGORY");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.IdCustomer).HasName("PK__CUSTOMER__7F6B0B8A659B0CC5");

            entity.ToTable("CUSTOMERS");

            entity.Property(e => e.IdCustomer).HasColumnName("ID_CUSTOMER");
            entity.Property(e => e.EmailCustomer)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("EMAIL_CUSTOMER");
            entity.Property(e => e.FamilyCustomer)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("FAMILY_CUSTOMER");
            entity.Property(e => e.NameCustomer)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NAME_CUSTOMER");
            entity.Property(e => e.PasswordCustomer)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PASSWORD_CUSTOMER");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.IdEmployee).HasName("PK__EMPLOYEE__FFDDC303E40126C4");

            entity.ToTable("EMPLOYEES");

            entity.Property(e => e.IdEmployee).HasColumnName("ID_EMPLOYEE");
            entity.Property(e => e.EmailEmployee)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("EMAIL_EMPLOYEE");
            entity.Property(e => e.FamilyEmployee)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("FAMILY_EMPLOYEE");
            entity.Property(e => e.IdStore).HasColumnName("ID_STORE");
            entity.Property(e => e.IsDelete).HasColumnName("IS_DELETE");
            entity.Property(e => e.NameEmployee)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NAME_EMPLOYEE");
            entity.Property(e => e.PasswordEmployee)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PASSWORD_EMPLOYEE");
            entity.Property(e => e.SalaryEmployee).HasColumnName("SALARY_EMPLOYEE");

            entity.HasOne(d => d.IdStoreNavigation).WithMany(p => p.Employees)
                .HasForeignKey(d => d.IdStore)
                .HasConstraintName("FK_EMPLOYEES_STORES");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.IdOrder).HasName("PK__ORDERS__D23A856502849142");

            entity.ToTable("ORDERS");

            entity.Property(e => e.IdOrder).HasColumnName("ID_ORDER");
            entity.Property(e => e.DateOrder).HasColumnName("DATE_ORDER");
            entity.Property(e => e.IdCustomer).HasColumnName("ID_CUSTOMER");
            entity.Property(e => e.IdEmployee).HasColumnName("ID_EMPLOYEE");

            entity.HasOne(d => d.IdCustomerNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdCustomer)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ORDERS_CUSTOMERS");

            entity.HasOne(d => d.IdEmployeeNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdEmployee)
                .HasConstraintName("FK_ORDERS_EMPLOYEES");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => e.IdDetail).HasName("PK__ORDER_DE__CA7FA6CE3979091B");

            entity.ToTable("ORDER_DETAILS");

            entity.Property(e => e.IdDetail).HasColumnName("ID_DETAIL");
            entity.Property(e => e.CountProduct).HasColumnName("COUNT_PRODUCT");
            entity.Property(e => e.IdOrder).HasColumnName("ID_ORDER");
            entity.Property(e => e.IdProduct).HasColumnName("ID_PRODUCT");

            entity.HasOne(d => d.IdOrderNavigation).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.IdOrder)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ORDER_DETAILS_ORDERS");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.IdProduct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ORDER_DETAILS_PRODUCTS");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.IdProduct).HasName("PK__PRODUCTS__69B20C20E40D7F24");

            entity.ToTable("PRODUCTS");

            entity.Property(e => e.IdProduct).HasColumnName("ID_PRODUCT");
            entity.Property(e => e.IdProvider).HasColumnName("ID_PROVIDER");
            entity.Property(e => e.IdTypeProduct).HasColumnName("ID_TYPE_PRODUCT");
            entity.Property(e => e.NameProduct)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NAME_PRODUCT");
            entity.Property(e => e.PriceProduct).HasColumnName("PRICE_PRODUCT");
            entity.Property(e => e.QuantityProduct).HasColumnName("QUANTITY_PRODUCT");
            entity.Property(e => e.RatingProduct).HasColumnName("RATING_PRODUCT");

            entity.HasOne(d => d.IdProviderNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdProvider)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PRODUCTS_PROVIDERS");

            entity.HasOne(d => d.IdTypeProductNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdTypeProduct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PRODUCTS_TYPES_PRODUCT");
        });

        modelBuilder.Entity<Provider>(entity =>
        {
            entity.HasKey(e => e.IdProvider).HasName("PK__PROVIDER__38BF7C1D0E7810D5");

            entity.ToTable("PROVIDERS");

            entity.Property(e => e.IdProvider).HasColumnName("ID_PROVIDER");
            entity.Property(e => e.NameProvider)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NAME_PROVIDER");
        });

        modelBuilder.Entity<Store>(entity =>
        {
            entity.HasKey(e => e.IdStore).HasName("PK__STORES__C263140C3A8F7795");

            entity.ToTable("STORES", tb => tb.HasTrigger("DELETE_STORES"));

            entity.Property(e => e.IdStore).HasColumnName("ID_STORE");
            entity.Property(e => e.CityStore)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CITY_STORE");
            entity.Property(e => e.HouseStore)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("HOUSE_STORE");
            entity.Property(e => e.IsDelete).HasColumnName("IS_DELETE");
            entity.Property(e => e.NumberStore)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NUMBER_STORE");
            entity.Property(e => e.RatingStore).HasColumnName("RATING_STORE");
            entity.Property(e => e.StreetStore)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("STREET_STORE");
        });

        modelBuilder.Entity<TypesProduct>(entity =>
        {
            entity.HasKey(e => e.IdTypeProduct).HasName("PK__TYPES_PR__371569981911CD1E");

            entity.ToTable("TYPES_PRODUCT");

            entity.Property(e => e.IdTypeProduct).HasColumnName("ID_TYPE_PRODUCT");
            entity.Property(e => e.IdCategory).HasColumnName("ID_CATEGORY");
            entity.Property(e => e.NameTypeProduct)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NAME_TYPE_PRODUCT");

            entity.HasOne(d => d.IdCategoryNavigation).WithMany(p => p.TypesProducts)
                .HasForeignKey(d => d.IdCategory)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TYPES_PRODUCT_CATEGORIES");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
