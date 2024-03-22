using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestCoreApi.Migrations
{
    /// <inheritdoc />
    public partial class AddFeesFrequncy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FeeFrequency",
                table: "Fees",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FeeFrequency",
                table: "Fees");
        }
    }
}
