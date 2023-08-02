using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClothesSaleManagement.Infrastructure.Migrations
{
    public partial class InitialDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bill",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalPayment = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bill", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Size",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Size", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CostPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AvailableQuantity = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SizeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_Size_SizeId",
                        column: x => x.SizeId,
                        principalTable: "Size",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BillDetail",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalMoney = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BillId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BillDetail_Bill_BillId",
                        column: x => x.BillId,
                        principalTable: "Bill",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BillDetail_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartDetail",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    CartId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartDetail_Cart_CartId",
                        column: x => x.CartId,
                        principalTable: "Cart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartDetail_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Bill",
                columns: new[] { "Id", "CreatedDate", "CustomerName", "PhoneNumber", "Status", "TotalPayment" },
                values: new object[,]
                {
                    { new Guid("b2262bf3-7a66-465f-88ca-230c757e6287"), new DateTime(2023, 8, 2, 17, 57, 17, 109, DateTimeKind.Local).AddTicks(3904), "Nguyễn Ngọc Diệp", "0132312342", 1, 200000m },
                    { new Guid("cc0b414e-9eab-4527-b3fb-6efba68748ff"), new DateTime(2023, 8, 2, 17, 57, 17, 109, DateTimeKind.Local).AddTicks(3888), "Lê Xuân Minh Chiến", "0123123423", 1, 20000m },
                    { new Guid("fe382f6d-a7fc-4f6e-9843-239f0d6284bf"), new DateTime(2023, 8, 2, 17, 57, 17, 109, DateTimeKind.Local).AddTicks(3901), "Nguyễn Ngọc Diệp ", "0132312342", 1, 100000m }
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name", "Status" },
                values: new object[,]
                {
                    { new Guid("b4a85960-d2b0-45b6-8fed-015fe61b5016"), "Áo phông", 0 },
                    { new Guid("dcb0eb8d-d2a7-4849-bb94-47049486567f"), "T-Shirt", 0 },
                    { new Guid("fe702e57-9cb1-4c9f-8157-b0d19b1a7c03"), "Top tank", 0 }
                });

            migrationBuilder.InsertData(
                table: "Size",
                columns: new[] { "Id", "Name", "Status" },
                values: new object[,]
                {
                    { new Guid("2a765a9f-2dca-41d3-9570-e1ce39dc1f28"), "M", 0 },
                    { new Guid("af100821-2fd2-4d2d-a95e-04c772bceeb6"), "L", 0 },
                    { new Guid("f306c6f6-8a72-4c20-9031-2310cf8bf042"), "S", 0 }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "AvailableQuantity", "CategoryId", "CostPrice", "CreatedDate", "Description", "ImageUrl", "ModifiedDate", "Name", "Price", "SizeId", "Status" },
                values: new object[] { new Guid("66bdf5a9-58b0-42b8-8508-c95e2518582a"), 100, new Guid("dcb0eb8d-d2a7-4849-bb94-47049486567f"), 20000m, new DateTime(2023, 8, 2, 17, 57, 17, 110, DateTimeKind.Local).AddTicks(1197), "Thoáng mát", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Áo T-shirt co dãn", 50000m, new Guid("af100821-2fd2-4d2d-a95e-04c772bceeb6"), 0 });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "AvailableQuantity", "CategoryId", "CostPrice", "CreatedDate", "Description", "ImageUrl", "ModifiedDate", "Name", "Price", "SizeId", "Status" },
                values: new object[] { new Guid("c1abc698-7149-49e2-b67f-e50f09d8e0c0"), 100, new Guid("fe702e57-9cb1-4c9f-8157-b0d19b1a7c03"), 50000m, new DateTime(2023, 8, 2, 17, 57, 17, 110, DateTimeKind.Local).AddTicks(1187), "Sang xịn mịn", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Áo phông chanh xả", 100000m, new Guid("f306c6f6-8a72-4c20-9031-2310cf8bf042"), 0 });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "AvailableQuantity", "CategoryId", "CostPrice", "CreatedDate", "Description", "ImageUrl", "ModifiedDate", "Name", "Price", "SizeId", "Status" },
                values: new object[] { new Guid("ed884572-cdeb-46ad-a2b2-12297e9fd32a"), 100, new Guid("dcb0eb8d-d2a7-4849-bb94-47049486567f"), 20000m, new DateTime(2023, 8, 2, 17, 57, 17, 110, DateTimeKind.Local).AddTicks(1193), "Sang xịn mịn", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Áo top tank sẹc xi", 50000m, new Guid("af100821-2fd2-4d2d-a95e-04c772bceeb6"), 0 });

            migrationBuilder.InsertData(
                table: "BillDetail",
                columns: new[] { "Id", "BillId", "Price", "ProductId", "Quantity", "TotalMoney" },
                values: new object[,]
                {
                    { new Guid("18f91fdb-39d3-4fcc-b8ca-896ef777d840"), new Guid("fe382f6d-a7fc-4f6e-9843-239f0d6284bf"), 25000m, new Guid("ed884572-cdeb-46ad-a2b2-12297e9fd32a"), 2, 50000m },
                    { new Guid("374bf0a6-039f-42a9-b232-e4c90998b4c2"), new Guid("fe382f6d-a7fc-4f6e-9843-239f0d6284bf"), 10000m, new Guid("ed884572-cdeb-46ad-a2b2-12297e9fd32a"), 5, 50000m },
                    { new Guid("574ee723-685c-4bfa-8235-44d085434b74"), new Guid("b2262bf3-7a66-465f-88ca-230c757e6287"), 100000m, new Guid("66bdf5a9-58b0-42b8-8508-c95e2518582a"), 2, 200000m },
                    { new Guid("b8d733f0-6745-4be3-9072-39c4a52c803f"), new Guid("cc0b414e-9eab-4527-b3fb-6efba68748ff"), 20000m, new Guid("c1abc698-7149-49e2-b67f-e50f09d8e0c0"), 1, 20000m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BillDetail_BillId",
                table: "BillDetail",
                column: "BillId");

            migrationBuilder.CreateIndex(
                name: "IX_BillDetail_ProductId",
                table: "BillDetail",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_CartDetail_CartId",
                table: "CartDetail",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartDetail_ProductId",
                table: "CartDetail",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryId",
                table: "Product",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_SizeId",
                table: "Product",
                column: "SizeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BillDetail");

            migrationBuilder.DropTable(
                name: "CartDetail");

            migrationBuilder.DropTable(
                name: "Bill");

            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Size");
        }
    }
}
