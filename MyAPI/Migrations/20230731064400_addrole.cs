using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyAPI.Migrations
{
    /// <inheritdoc />
    public partial class addrole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3a9402ca-d26b-4c6d-8e04-8a653db201a0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cb79ec66-f91c-4769-ba15-60cb94b049c2");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "094f0529-4d20-4470-8add-9288ec22b89f", "49c7c5ff-c20c-4ecf-b321-efa93269b27f", "User", "USER" },
                    { "b5633a7b-e16b-4380-9d78-dcc738f50f56", "ac17e512-83b8-4c76-bd34-4d613274c265", "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "094f0529-4d20-4470-8add-9288ec22b89f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b5633a7b-e16b-4380-9d78-dcc738f50f56");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3a9402ca-d26b-4c6d-8e04-8a653db201a0", "606dd62c-df30-4bf9-9b7d-f2e030cc8724", "User", "USER" },
                    { "cb79ec66-f91c-4769-ba15-60cb94b049c2", "4f46d4a9-84f7-4f36-a3a6-6cdff5f77cd4", "Admin", "ADMIN" }
                });
        }
    }
}
