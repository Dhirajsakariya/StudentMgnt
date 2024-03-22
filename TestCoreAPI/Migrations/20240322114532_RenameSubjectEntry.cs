using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestCoreApi.Migrations
{
    /// <inheritdoc />
    public partial class RenameSubjectEntry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("0416e0ea-3c21-4ec8-95d4-3fb5750409c8"),
                column: "Name",
                value: "Gujarati");

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("08965a20-5133-4973-8abe-880ee4c9d459"),
                column: "Name",
                value: "Gujarati");

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("1c932ef0-6e4e-4745-9887-b73148594b40"),
                column: "Name",
                value: "Gujarati");

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("45caf56f-3a19-4ffd-b440-58efe9636348"),
                column: "Name",
                value: "Gujarati");

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("8c2c6493-7967-450c-aa4b-1e1b08470dca"),
                column: "Name",
                value: "Gujarati");

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("932978e9-6ebe-46f0-8440-bbc08d4419f4"),
                column: "Name",
                value: "Gujarati");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("0416e0ea-3c21-4ec8-95d4-3fb5750409c8"),
                column: "Name",
                value: "Gujrati");

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("08965a20-5133-4973-8abe-880ee4c9d459"),
                column: "Name",
                value: "Gujrati");

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("1c932ef0-6e4e-4745-9887-b73148594b40"),
                column: "Name",
                value: "Gujrati");

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("45caf56f-3a19-4ffd-b440-58efe9636348"),
                column: "Name",
                value: "Gujrati");

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("8c2c6493-7967-450c-aa4b-1e1b08470dca"),
                column: "Name",
                value: "Gujrati");

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("932978e9-6ebe-46f0-8440-bbc08d4419f4"),
                column: "Name",
                value: "Gujrati");
        }
    }
}
