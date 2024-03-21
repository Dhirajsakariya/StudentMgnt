using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TestCoreApi.Migrations
{
    /// <inheritdoc />
    public partial class AddStandardEntityEntry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData( 
                table: "Standards",
                columns: new[] { "Id", "Section", "StandardNumber" },
                values: new object[,]
                {
                    { new Guid("1ecc5761-7ddb-4ef7-8b16-28c91845a386"), "A", 10 },
                    { new Guid("3241a142-031d-41e4-a1ba-239efc8559f7"), "B", 9 },
                    { new Guid("49716b8a-aca6-4ce9-9a74-199ce2a5af40"), "A", 9 },
                    { new Guid("a8283465-6ae7-43d6-8eca-09c02ab12b4c"), "A", 8 },
                    { new Guid("b880223f-458f-4e5f-a012-313119be3724"), "B", 10 },
                    { new Guid("f82ba9d1-5d85-4c20-bca0-142dd07e1316"), "B", 8 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Standards",
                keyColumn: "Id",
                keyValue: new Guid("1ecc5761-7ddb-4ef7-8b16-28c91845a386"));

            migrationBuilder.DeleteData(
                table: "Standards",
                keyColumn: "Id",
                keyValue: new Guid("3241a142-031d-41e4-a1ba-239efc8559f7"));

            migrationBuilder.DeleteData(
                table: "Standards",
                keyColumn: "Id",
                keyValue: new Guid("49716b8a-aca6-4ce9-9a74-199ce2a5af40"));

            migrationBuilder.DeleteData(
                table: "Standards",
                keyColumn: "Id",
                keyValue: new Guid("a8283465-6ae7-43d6-8eca-09c02ab12b4c"));

            migrationBuilder.DeleteData(
                table: "Standards",
                keyColumn: "Id",
                keyValue: new Guid("b880223f-458f-4e5f-a012-313119be3724"));

            migrationBuilder.DeleteData(
                table: "Standards",
                keyColumn: "Id",
                keyValue: new Guid("f82ba9d1-5d85-4c20-bca0-142dd07e1316"));
        }
    }
}
