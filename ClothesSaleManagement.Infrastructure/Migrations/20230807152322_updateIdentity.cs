using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClothesSaleManagement.Infrastructure.Migrations
{
    public partial class updateIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("cac43a6e-f7bb-4448-baaf-1add431ccbbf"), "c4d9c8f0-ca4c-44f1-9805-b861b1e5cec0", "Customer", "CUSTOMER" },
                    { new Guid("cbc43a8e-f7bb-4445-baaf-1add431ffbbf"), "c2453682-af5a-44eb-b1f8-91528b90e98c", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), 0, "1fe9fb0a-c06d-4794-9d69-38bce61b2f0b", "admin@localhost.com", true, "System", "Admin", false, null, "ADMIN@LOCALHOST.COM", "ADMIN@LOCALHOST.COM", "AQAAAAEAACcQAAAAEC41xnCDaiI3TM4r99sWgeoT3sbkw/1zf9nnaxYEGIr9OFMXlbdSmkn69BTEkil9ZQ==", null, false, null, false, "admin@localhost.com" },
                    { new Guid("9e224968-33e4-4652-b7b7-8574d048cdb9"), 0, "c8d7a753-d8f7-4550-ad5e-a9a9f1a5e961", "user@localhost.com", true, "System", "User", false, null, "USER@LOCALHOST.COM", "USER@LOCALHOST.COM", "AQAAAAEAACcQAAAAEE+P0Clm6ahgRVxbfPCAdd4VRjpd5siCdai4uyuseG4sEm9Dj6JrvwUMl9oPULfSEw==", null, false, null, false, "user@localhost.com" }
                });

            migrationBuilder.UpdateData(
                table: "Bill",
                keyColumn: "Id",
                keyValue: new Guid("b2262bf3-7a66-465f-88ca-230c757e6287"),
                column: "CreatedDate",
                value: new DateTime(2023, 8, 7, 22, 23, 22, 51, DateTimeKind.Local).AddTicks(6385));

            migrationBuilder.UpdateData(
                table: "Bill",
                keyColumn: "Id",
                keyValue: new Guid("cc0b414e-9eab-4527-b3fb-6efba68748ff"),
                column: "CreatedDate",
                value: new DateTime(2023, 8, 7, 22, 23, 22, 51, DateTimeKind.Local).AddTicks(6371));

            migrationBuilder.UpdateData(
                table: "Bill",
                keyColumn: "Id",
                keyValue: new Guid("fe382f6d-a7fc-4f6e-9843-239f0d6284bf"),
                column: "CreatedDate",
                value: new DateTime(2023, 8, 7, 22, 23, 22, 51, DateTimeKind.Local).AddTicks(6382));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("66bdf5a9-58b0-42b8-8508-c95e2518582a"),
                column: "CreatedDate",
                value: new DateTime(2023, 8, 7, 22, 23, 22, 54, DateTimeKind.Local).AddTicks(5832));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("c1abc698-7149-49e2-b67f-e50f09d8e0c0"),
                column: "CreatedDate",
                value: new DateTime(2023, 8, 7, 22, 23, 22, 54, DateTimeKind.Local).AddTicks(5821));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("ed884572-cdeb-46ad-a2b2-12297e9fd32a"),
                column: "CreatedDate",
                value: new DateTime(2023, 8, 7, 22, 23, 22, 54, DateTimeKind.Local).AddTicks(5828));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("cbc43a8e-f7bb-4445-baaf-1add431ffbbf"), new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9") });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("cac43a6e-f7bb-4448-baaf-1add431ccbbf"), new Guid("9e224968-33e4-4652-b7b7-8574d048cdb9") });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "Bill",
                keyColumn: "Id",
                keyValue: new Guid("b2262bf3-7a66-465f-88ca-230c757e6287"),
                column: "CreatedDate",
                value: new DateTime(2023, 8, 7, 16, 34, 8, 540, DateTimeKind.Local).AddTicks(8817));

            migrationBuilder.UpdateData(
                table: "Bill",
                keyColumn: "Id",
                keyValue: new Guid("cc0b414e-9eab-4527-b3fb-6efba68748ff"),
                column: "CreatedDate",
                value: new DateTime(2023, 8, 7, 16, 34, 8, 540, DateTimeKind.Local).AddTicks(8803));

            migrationBuilder.UpdateData(
                table: "Bill",
                keyColumn: "Id",
                keyValue: new Guid("fe382f6d-a7fc-4f6e-9843-239f0d6284bf"),
                column: "CreatedDate",
                value: new DateTime(2023, 8, 7, 16, 34, 8, 540, DateTimeKind.Local).AddTicks(8814));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("66bdf5a9-58b0-42b8-8508-c95e2518582a"),
                column: "CreatedDate",
                value: new DateTime(2023, 8, 7, 16, 34, 8, 541, DateTimeKind.Local).AddTicks(5652));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("c1abc698-7149-49e2-b67f-e50f09d8e0c0"),
                column: "CreatedDate",
                value: new DateTime(2023, 8, 7, 16, 34, 8, 541, DateTimeKind.Local).AddTicks(5605));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("ed884572-cdeb-46ad-a2b2-12297e9fd32a"),
                column: "CreatedDate",
                value: new DateTime(2023, 8, 7, 16, 34, 8, 541, DateTimeKind.Local).AddTicks(5611));
        }
    }
}
