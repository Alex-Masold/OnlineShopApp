﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnlineShopApp.DataSource;

#nullable disable

namespace OnlineShopApp.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20240502185814_~")]
    partial class _
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("OnlineShopApp.Models.Category", b =>
                {
                    b.Property<int>("IdCategory")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_CATEGORY");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCategory"));

                    b.Property<string>("NameCategory")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("NAME_CATEGORY");

                    b.HasKey("IdCategory")
                        .HasName("PK__CATEGORI__EC9B18B766163D6A");

                    b.ToTable("CATEGORIES", (string)null);
                });

            modelBuilder.Entity("OnlineShopApp.Models.Customer", b =>
                {
                    b.Property<int>("IdCustomer")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_CUSTOMER");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCustomer"));

                    b.Property<string>("EmailCustomer")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("EMAIL_CUSTOMER");

                    b.Property<string>("FamilyCustomer")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("FAMILY_CUSTOMER");

                    b.Property<string>("NameCustomer")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("NAME_CUSTOMER");

                    b.Property<string>("PasswordCustomer")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("PASSWORD_CUSTOMER");

                    b.HasKey("IdCustomer")
                        .HasName("PK__CUSTOMER__7F6B0B8A659B0CC5");

                    b.ToTable("CUSTOMERS", (string)null);
                });

            modelBuilder.Entity("OnlineShopApp.Models.Employee", b =>
                {
                    b.Property<int>("IdEmployee")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_EMPLOYEE");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEmployee"));

                    b.Property<string>("EmailEmployee")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("EMAIL_EMPLOYEE");

                    b.Property<string>("FamilyEmployee")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("FAMILY_EMPLOYEE");

                    b.Property<int?>("IdStore")
                        .HasColumnType("int")
                        .HasColumnName("ID_STORE");

                    b.Property<bool?>("IsDelete")
                        .HasColumnType("bit")
                        .HasColumnName("IS_DELETE");

                    b.Property<string>("NameEmployee")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("NAME_EMPLOYEE");

                    b.Property<string>("PasswordEmployee")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("PASSWORD_EMPLOYEE");

                    b.Property<int?>("SalaryEmployee")
                        .HasColumnType("int")
                        .HasColumnName("SALARY_EMPLOYEE");

                    b.HasKey("IdEmployee")
                        .HasName("PK__EMPLOYEE__FFDDC303E40126C4");

                    b.HasIndex("IdStore");

                    b.ToTable("EMPLOYEES", (string)null);
                });

            modelBuilder.Entity("OnlineShopApp.Models.Order", b =>
                {
                    b.Property<int>("IdOrder")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_ORDER");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdOrder"));

                    b.Property<DateOnly?>("DateOrder")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("date")
                        .HasDefaultValue(new DateOnly(2024, 5, 3))
                        .HasColumnName("DATE_ORDER");

                    b.Property<int?>("IdCustomer")
                        .HasColumnType("int")
                        .HasColumnName("ID_CUSTOMER");

                    b.Property<int?>("IdEmployee")
                        .HasColumnType("int");

                    b.Property<int?>("IdOrderStatus")
                        .HasColumnType("int")
                        .HasColumnName("ID_ORDER_STATUS");

                    b.Property<int?>("IdStore")
                        .HasColumnType("int")
                        .HasColumnName("ID_STORE");

                    b.HasKey("IdOrder")
                        .HasName("PK__ORDERS__D23A856502849142");

                    b.HasIndex("IdCustomer");

                    b.HasIndex("IdEmployee");

                    b.HasIndex("IdOrderStatus");

                    b.HasIndex("IdStore");

                    b.ToTable("ORDERS", (string)null);
                });

            modelBuilder.Entity("OnlineShopApp.Models.OrderDetail", b =>
                {
                    b.Property<int>("IdDetail")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_DETAIL");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdDetail"));

                    b.Property<int?>("CountProduct")
                        .HasColumnType("int")
                        .HasColumnName("COUNT_PRODUCT");

                    b.Property<int?>("IdOrder")
                        .HasColumnType("int")
                        .HasColumnName("ID_ORDER");

                    b.Property<int?>("IdProduct")
                        .HasColumnType("int")
                        .HasColumnName("ID_PRODUCT");

                    b.HasKey("IdDetail")
                        .HasName("PK__ORDER_DE__CA7FA6CE3979091B");

                    b.HasIndex("IdOrder");

                    b.HasIndex("IdProduct");

                    b.ToTable("ORDER_DETAILS", (string)null);
                });

            modelBuilder.Entity("OnlineShopApp.Models.OrderStatus", b =>
                {
                    b.Property<int>("IdStatus")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_STATUS");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdStatus"));

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("STATUS");

                    b.HasKey("IdStatus");

                    b.ToTable("ORDER_STATUS", (string)null);
                });

            modelBuilder.Entity("OnlineShopApp.Models.Product", b =>
                {
                    b.Property<int>("IdProduct")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_PRODUCT");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdProduct"));

                    b.Property<int?>("IdProvider")
                        .HasColumnType("int")
                        .HasColumnName("ID_PROVIDER");

                    b.Property<int?>("IdTypeProduct")
                        .HasColumnType("int")
                        .HasColumnName("ID_TYPE_PRODUCT");

                    b.Property<string>("NameProduct")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("NAME_PRODUCT");

                    b.Property<int?>("PriceProduct")
                        .HasColumnType("int")
                        .HasColumnName("PRICE_PRODUCT");

                    b.Property<int?>("QuantityProduct")
                        .HasColumnType("int")
                        .HasColumnName("QUANTITY_PRODUCT");

                    b.Property<double?>("RatingProduct")
                        .HasColumnType("float")
                        .HasColumnName("RATING_PRODUCT");

                    b.HasKey("IdProduct")
                        .HasName("PK__PRODUCTS__69B20C20E40D7F24");

                    b.HasIndex("IdProvider");

                    b.HasIndex("IdTypeProduct");

                    b.ToTable("PRODUCTS", (string)null);
                });

            modelBuilder.Entity("OnlineShopApp.Models.Provider", b =>
                {
                    b.Property<int>("IdProvider")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_PROVIDER");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdProvider"));

                    b.Property<string>("NameProvider")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("NAME_PROVIDER");

                    b.HasKey("IdProvider")
                        .HasName("PK__PROVIDER__38BF7C1D0E7810D5");

                    b.ToTable("PROVIDERS", (string)null);
                });

            modelBuilder.Entity("OnlineShopApp.Models.Store", b =>
                {
                    b.Property<int>("IdStore")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_STORE");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdStore"));

                    b.Property<string>("CityStore")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("CITY_STORE");

                    b.Property<string>("HouseStore")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("HOUSE_STORE");

                    b.Property<bool?>("IsDelete")
                        .HasColumnType("bit")
                        .HasColumnName("IS_DELETE");

                    b.Property<string>("NumberStore")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("NUMBER_STORE");

                    b.Property<double?>("RatingStore")
                        .HasColumnType("float")
                        .HasColumnName("RATING_STORE");

                    b.Property<string>("StreetStore")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("STREET_STORE");

                    b.HasKey("IdStore")
                        .HasName("PK__STORES__C263140C3A8F7795");

                    b.ToTable("STORES", null, t =>
                        {
                            t.HasTrigger("DELETE_STORES");
                        });

                    b.HasAnnotation("SqlServer:UseSqlOutputClause", false);
                });

            modelBuilder.Entity("OnlineShopApp.Models.TypesProduct", b =>
                {
                    b.Property<int>("IdTypeProduct")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_TYPE_PRODUCT");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTypeProduct"));

                    b.Property<int?>("IdCategory")
                        .HasColumnType("int")
                        .HasColumnName("ID_CATEGORY");

                    b.Property<string>("NameTypeProduct")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("NAME_TYPE_PRODUCT");

                    b.HasKey("IdTypeProduct")
                        .HasName("PK__TYPES_PR__371569981911CD1E");

                    b.HasIndex("IdCategory");

                    b.ToTable("TYPES_PRODUCT", (string)null);
                });

            modelBuilder.Entity("OnlineShopApp.Models.Employee", b =>
                {
                    b.HasOne("OnlineShopApp.Models.Store", "IdStoreNavigation")
                        .WithMany("Employees")
                        .HasForeignKey("IdStore")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .HasConstraintName("FK_EMPLOYEES_STORES");

                    b.Navigation("IdStoreNavigation");
                });

            modelBuilder.Entity("OnlineShopApp.Models.Order", b =>
                {
                    b.HasOne("OnlineShopApp.Models.Customer", "IdCustomerNavigation")
                        .WithMany("Orders")
                        .HasForeignKey("IdCustomer")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK_ORDERS_CUSTOMERS");

                    b.HasOne("OnlineShopApp.Models.Employee", "IdEmployeeNavigation")
                        .WithMany("Orders")
                        .HasForeignKey("IdEmployee")
                        .OnDelete(DeleteBehavior.NoAction)
                        .HasConstraintName("FK_ORDERS_EMPLOYEE");

                    b.HasOne("OnlineShopApp.Models.OrderStatus", "IdOrderStatusNavigation")
                        .WithMany("Orders")
                        .HasForeignKey("IdOrderStatus")
                        .HasConstraintName("FK_ORDERS_ORDER_STATUS");

                    b.HasOne("OnlineShopApp.Models.Store", "IdStoreNavigation")
                        .WithMany("Orders")
                        .HasForeignKey("IdStore")
                        .OnDelete(DeleteBehavior.NoAction)
                        .HasConstraintName("FK_ORDERS_STORE");

                    b.Navigation("IdCustomerNavigation");

                    b.Navigation("IdEmployeeNavigation");

                    b.Navigation("IdOrderStatusNavigation");

                    b.Navigation("IdStoreNavigation");
                });

            modelBuilder.Entity("OnlineShopApp.Models.OrderDetail", b =>
                {
                    b.HasOne("OnlineShopApp.Models.Order", "IdOrderNavigation")
                        .WithMany("OrderDetails")
                        .HasForeignKey("IdOrder")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK_ORDER_DETAILS_ORDERS");

                    b.HasOne("OnlineShopApp.Models.Product", "IdProductNavigation")
                        .WithMany("OrderDetails")
                        .HasForeignKey("IdProduct")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK_ORDER_DETAILS_PRODUCTS");

                    b.Navigation("IdOrderNavigation");

                    b.Navigation("IdProductNavigation");
                });

            modelBuilder.Entity("OnlineShopApp.Models.Product", b =>
                {
                    b.HasOne("OnlineShopApp.Models.Provider", "IdProviderNavigation")
                        .WithMany("Products")
                        .HasForeignKey("IdProvider")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK_PRODUCTS_PROVIDERS");

                    b.HasOne("OnlineShopApp.Models.TypesProduct", "IdTypeProductNavigation")
                        .WithMany("Products")
                        .HasForeignKey("IdTypeProduct")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK_PRODUCTS_TYPES_PRODUCT");

                    b.Navigation("IdProviderNavigation");

                    b.Navigation("IdTypeProductNavigation");
                });

            modelBuilder.Entity("OnlineShopApp.Models.TypesProduct", b =>
                {
                    b.HasOne("OnlineShopApp.Models.Category", "IdCategoryNavigation")
                        .WithMany("TypesProducts")
                        .HasForeignKey("IdCategory")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK_TYPES_PRODUCT_CATEGORIES");

                    b.Navigation("IdCategoryNavigation");
                });

            modelBuilder.Entity("OnlineShopApp.Models.Category", b =>
                {
                    b.Navigation("TypesProducts");
                });

            modelBuilder.Entity("OnlineShopApp.Models.Customer", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("OnlineShopApp.Models.Employee", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("OnlineShopApp.Models.Order", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("OnlineShopApp.Models.OrderStatus", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("OnlineShopApp.Models.Product", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("OnlineShopApp.Models.Provider", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("OnlineShopApp.Models.Store", b =>
                {
                    b.Navigation("Employees");

                    b.Navigation("Orders");
                });

            modelBuilder.Entity("OnlineShopApp.Models.TypesProduct", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
