﻿// <auto-generated />
using System;
using ClothesSaleManagement.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ClothesSaleManagement.Infrastructure.Migrations
{
    [DbContext(typeof(ClothesSaleManagementContext))]
    [Migration("20230807152322_updateIdentity")]
    partial class updateIdentity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ClothesSaleManagement.Domain.Bill", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalPayment")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Bill", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("cc0b414e-9eab-4527-b3fb-6efba68748ff"),
                            CreatedDate = new DateTime(2023, 8, 7, 22, 23, 22, 51, DateTimeKind.Local).AddTicks(6371),
                            CustomerName = "Lê Xuân Minh Chiến",
                            PhoneNumber = "0123123423",
                            Status = 1,
                            TotalPayment = 20000m
                        },
                        new
                        {
                            Id = new Guid("fe382f6d-a7fc-4f6e-9843-239f0d6284bf"),
                            CreatedDate = new DateTime(2023, 8, 7, 22, 23, 22, 51, DateTimeKind.Local).AddTicks(6382),
                            CustomerName = "Nguyễn Ngọc Diệp ",
                            PhoneNumber = "0132312342",
                            Status = 1,
                            TotalPayment = 100000m
                        },
                        new
                        {
                            Id = new Guid("b2262bf3-7a66-465f-88ca-230c757e6287"),
                            CreatedDate = new DateTime(2023, 8, 7, 22, 23, 22, 51, DateTimeKind.Local).AddTicks(6385),
                            CustomerName = "Nguyễn Ngọc Diệp",
                            PhoneNumber = "0132312342",
                            Status = 1,
                            TotalPayment = 200000m
                        });
                });

            modelBuilder.Entity("ClothesSaleManagement.Domain.BillDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BillId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("ProductDetailId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalMoney")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("BillId");

                    b.HasIndex("ProductDetailId");

                    b.ToTable("BillDetail", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("b8d733f0-6745-4be3-9072-39c4a52c803f"),
                            BillId = new Guid("cc0b414e-9eab-4527-b3fb-6efba68748ff"),
                            Price = 20000m,
                            ProductDetailId = new Guid("25e52937-d44f-4d2f-bc7f-67cbc6efd064"),
                            Quantity = 1,
                            TotalMoney = 20000m
                        },
                        new
                        {
                            Id = new Guid("18f91fdb-39d3-4fcc-b8ca-896ef777d840"),
                            BillId = new Guid("fe382f6d-a7fc-4f6e-9843-239f0d6284bf"),
                            Price = 25000m,
                            ProductDetailId = new Guid("122a5c7d-33f9-461d-8451-06e325e852f6"),
                            Quantity = 2,
                            TotalMoney = 50000m
                        },
                        new
                        {
                            Id = new Guid("374bf0a6-039f-42a9-b232-e4c90998b4c2"),
                            BillId = new Guid("fe382f6d-a7fc-4f6e-9843-239f0d6284bf"),
                            Price = 10000m,
                            ProductDetailId = new Guid("056ac6f7-c203-4fcd-9727-6d702c2be6a5"),
                            Quantity = 5,
                            TotalMoney = 50000m
                        },
                        new
                        {
                            Id = new Guid("574ee723-685c-4bfa-8235-44d085434b74"),
                            BillId = new Guid("b2262bf3-7a66-465f-88ca-230c757e6287"),
                            Price = 100000m,
                            ProductDetailId = new Guid("122a5c7d-33f9-461d-8451-06e325e852f6"),
                            Quantity = 2,
                            TotalMoney = 200000m
                        });
                });

            modelBuilder.Entity("ClothesSaleManagement.Domain.Cart", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Id");

                    b.ToTable("Cart", (string)null);
                });

            modelBuilder.Entity("ClothesSaleManagement.Domain.CartDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CartId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductDetailId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.HasIndex("ProductDetailId");

                    b.ToTable("CartDetail", (string)null);
                });

            modelBuilder.Entity("ClothesSaleManagement.Domain.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Category", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("fe702e57-9cb1-4c9f-8157-b0d19b1a7c03"),
                            Name = "Top tank",
                            Status = 0
                        },
                        new
                        {
                            Id = new Guid("dcb0eb8d-d2a7-4849-bb94-47049486567f"),
                            Name = "T-Shirt",
                            Status = 0
                        },
                        new
                        {
                            Id = new Guid("b4a85960-d2b0-45b6-8fed-015fe61b5016"),
                            Name = "Áo phông",
                            Status = 0
                        });
                });

            modelBuilder.Entity("ClothesSaleManagement.Domain.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("CostPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Product", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("c1abc698-7149-49e2-b67f-e50f09d8e0c0"),
                            CategoryId = new Guid("fe702e57-9cb1-4c9f-8157-b0d19b1a7c03"),
                            CostPrice = 50000m,
                            CreatedDate = new DateTime(2023, 8, 7, 22, 23, 22, 54, DateTimeKind.Local).AddTicks(5821),
                            Description = "Sang xịn mịn",
                            ImageUrl = "",
                            Name = "Áo phông chanh xả",
                            Price = 100000m,
                            Status = 0
                        },
                        new
                        {
                            Id = new Guid("ed884572-cdeb-46ad-a2b2-12297e9fd32a"),
                            CategoryId = new Guid("dcb0eb8d-d2a7-4849-bb94-47049486567f"),
                            CostPrice = 20000m,
                            CreatedDate = new DateTime(2023, 8, 7, 22, 23, 22, 54, DateTimeKind.Local).AddTicks(5828),
                            Description = "Sang xịn mịn",
                            ImageUrl = "",
                            Name = "Áo top tank sẹc xi",
                            Price = 50000m,
                            Status = 0
                        },
                        new
                        {
                            Id = new Guid("66bdf5a9-58b0-42b8-8508-c95e2518582a"),
                            CategoryId = new Guid("dcb0eb8d-d2a7-4849-bb94-47049486567f"),
                            CostPrice = 20000m,
                            CreatedDate = new DateTime(2023, 8, 7, 22, 23, 22, 54, DateTimeKind.Local).AddTicks(5832),
                            Description = "Thoáng mát",
                            ImageUrl = "",
                            Name = "Áo T-shirt co dãn",
                            Price = 50000m,
                            Status = 0
                        });
                });

            modelBuilder.Entity("ClothesSaleManagement.Domain.ProductDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Size")
                        .HasColumnType("int");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductDetail", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("25e52937-d44f-4d2f-bc7f-67cbc6efd064"),
                            ProductId = new Guid("c1abc698-7149-49e2-b67f-e50f09d8e0c0"),
                            Size = 0,
                            Stock = 100
                        },
                        new
                        {
                            Id = new Guid("056ac6f7-c203-4fcd-9727-6d702c2be6a5"),
                            ProductId = new Guid("c1abc698-7149-49e2-b67f-e50f09d8e0c0"),
                            Size = 1,
                            Stock = 200
                        },
                        new
                        {
                            Id = new Guid("122a5c7d-33f9-461d-8451-06e325e852f6"),
                            ProductId = new Guid("ed884572-cdeb-46ad-a2b2-12297e9fd32a"),
                            Size = 4,
                            Stock = 100
                        },
                        new
                        {
                            Id = new Guid("f288069e-65e0-404e-bc36-4409cb42a63d"),
                            ProductId = new Guid("ed884572-cdeb-46ad-a2b2-12297e9fd32a"),
                            Size = 2,
                            Stock = 50
                        });
                });

            modelBuilder.Entity("ClothesSaleManagement.Infrastructure.Identity.Model.ApplicationUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "1fe9fb0a-c06d-4794-9d69-38bce61b2f0b",
                            Email = "admin@localhost.com",
                            EmailConfirmed = true,
                            FirstName = "System",
                            LastName = "Admin",
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@LOCALHOST.COM",
                            NormalizedUserName = "ADMIN@LOCALHOST.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEC41xnCDaiI3TM4r99sWgeoT3sbkw/1zf9nnaxYEGIr9OFMXlbdSmkn69BTEkil9ZQ==",
                            PhoneNumberConfirmed = false,
                            TwoFactorEnabled = false,
                            UserName = "admin@localhost.com"
                        },
                        new
                        {
                            Id = new Guid("9e224968-33e4-4652-b7b7-8574d048cdb9"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "c8d7a753-d8f7-4550-ad5e-a9a9f1a5e961",
                            Email = "user@localhost.com",
                            EmailConfirmed = true,
                            FirstName = "System",
                            LastName = "User",
                            LockoutEnabled = false,
                            NormalizedEmail = "USER@LOCALHOST.COM",
                            NormalizedUserName = "USER@LOCALHOST.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEE+P0Clm6ahgRVxbfPCAdd4VRjpd5siCdai4uyuseG4sEm9Dj6JrvwUMl9oPULfSEw==",
                            PhoneNumberConfirmed = false,
                            TwoFactorEnabled = false,
                            UserName = "user@localhost.com"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("cac43a6e-f7bb-4448-baaf-1add431ccbbf"),
                            ConcurrencyStamp = "c4d9c8f0-ca4c-44f1-9805-b861b1e5cec0",
                            Name = "Customer",
                            NormalizedName = "CUSTOMER"
                        },
                        new
                        {
                            Id = new Guid("cbc43a8e-f7bb-4445-baaf-1add431ffbbf"),
                            ConcurrencyStamp = "c2453682-af5a-44eb-b1f8-91528b90e98c",
                            Name = "Administrator",
                            NormalizedName = "ADMINISTRATOR"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                            RoleId = new Guid("cbc43a8e-f7bb-4445-baaf-1add431ffbbf")
                        },
                        new
                        {
                            UserId = new Guid("9e224968-33e4-4652-b7b7-8574d048cdb9"),
                            RoleId = new Guid("cac43a6e-f7bb-4448-baaf-1add431ccbbf")
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("ClothesSaleManagement.Domain.BillDetail", b =>
                {
                    b.HasOne("ClothesSaleManagement.Domain.Bill", "Bil")
                        .WithMany("BillDetails")
                        .HasForeignKey("BillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClothesSaleManagement.Domain.ProductDetail", "ProductDetail")
                        .WithMany("BillDetails")
                        .HasForeignKey("ProductDetailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bil");

                    b.Navigation("ProductDetail");
                });

            modelBuilder.Entity("ClothesSaleManagement.Domain.CartDetail", b =>
                {
                    b.HasOne("ClothesSaleManagement.Domain.Cart", "Cart")
                        .WithMany("CartDetails")
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClothesSaleManagement.Domain.ProductDetail", "ProductDetail")
                        .WithMany("CartDetails")
                        .HasForeignKey("ProductDetailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cart");

                    b.Navigation("ProductDetail");
                });

            modelBuilder.Entity("ClothesSaleManagement.Domain.Product", b =>
                {
                    b.HasOne("ClothesSaleManagement.Domain.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("ClothesSaleManagement.Domain.ProductDetail", b =>
                {
                    b.HasOne("ClothesSaleManagement.Domain.Product", "Product")
                        .WithMany("ProductDetails")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("ClothesSaleManagement.Infrastructure.Identity.Model.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("ClothesSaleManagement.Infrastructure.Identity.Model.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClothesSaleManagement.Infrastructure.Identity.Model.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("ClothesSaleManagement.Infrastructure.Identity.Model.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ClothesSaleManagement.Domain.Bill", b =>
                {
                    b.Navigation("BillDetails");
                });

            modelBuilder.Entity("ClothesSaleManagement.Domain.Cart", b =>
                {
                    b.Navigation("CartDetails");
                });

            modelBuilder.Entity("ClothesSaleManagement.Domain.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("ClothesSaleManagement.Domain.Product", b =>
                {
                    b.Navigation("ProductDetails");
                });

            modelBuilder.Entity("ClothesSaleManagement.Domain.ProductDetail", b =>
                {
                    b.Navigation("BillDetails");

                    b.Navigation("CartDetails");
                });
#pragma warning restore 612, 618
        }
    }
}