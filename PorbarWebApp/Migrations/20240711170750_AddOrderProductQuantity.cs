using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PorbarWebApp.Migrations
{
    /// <inheritdoc />
    public partial class AddOrderProductQuantity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "caf33229-37f1-4194-867a-cf8e31ead83a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e95e83ae-1613-4192-960c-a722285aecef");

            migrationBuilder.AddColumn<int>(
                name: "ProductQuantity",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductQuantity",
                table: "Orders");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "caf33229-37f1-4194-867a-cf8e31ead83a", null, "Admin", "ADMIN" },
                    { "e95e83ae-1613-4192-960c-a722285aecef", null, "User", "USER" }
                });
        }
    }
}
