using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Users.Persistence.EF.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    AddressId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.AddressId);
                });

            migrationBuilder.CreateTable(
                name: "UserProfileSettings",
                columns: table => new
                {
                    UserProfileSettingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false),
                    IsExtraUser = table.Column<bool>(type: "bit", nullable: false),
                    FavouriteFrontendFramework = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfileSettings", x => x.UserProfileSettingId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserAddressId = table.Column<int>(type: "int", nullable: false),
                    UserProfileSettingId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Addresses_UserAddressId",
                        column: x => x.UserAddressId,
                        principalTable: "Addresses",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_UserProfileSettings_UserProfileSettingId",
                        column: x => x.UserProfileSettingId,
                        principalTable: "UserProfileSettings",
                        principalColumn: "UserProfileSettingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "AddressId", "City", "Country", "PostCode", "Street" },
                values: new object[,]
                {
                    { 1, "Wroclaw", "Poland", "50-008", "Kosciuszki" },
                    { 2, "Kielce", "Poland", "25-351", "Kosciuszki" }
                });

            migrationBuilder.InsertData(
                table: "UserProfileSettings",
                columns: new[] { "UserProfileSettingId", "DateOfBirth", "FavouriteFrontendFramework", "IsAdmin", "IsExtraUser" },
                values: new object[,]
                {
                    { 1, new DateTime(1996, 12, 9, 0, 0, 0, 0, DateTimeKind.Local), "React", true, false },
                    { 2, new DateTime(2001, 12, 9, 0, 0, 0, 0, DateTimeKind.Local), "Vue.JS", false, true }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "CreatedBy", "CreatedOn", "EmailAddress", "LastModifiedBy", "LastModifiedDate", "Name", "Surname", "UserAddressId", "UserProfileSettingId" },
                values: new object[] { 1, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "bartek.wlodarz@gmail.com", null, null, "Bartek", "Wlodarz", 1, 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "CreatedBy", "CreatedOn", "EmailAddress", "LastModifiedBy", "LastModifiedDate", "Name", "Surname", "UserAddressId", "UserProfileSettingId" },
                values: new object[] { 2, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "dawid.wlodarz@gmail.com", null, null, "Dawid", "Wlodarz", 2, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserAddressId",
                table: "Users",
                column: "UserAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserProfileSettingId",
                table: "Users",
                column: "UserProfileSettingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "UserProfileSettings");
        }
    }
}
