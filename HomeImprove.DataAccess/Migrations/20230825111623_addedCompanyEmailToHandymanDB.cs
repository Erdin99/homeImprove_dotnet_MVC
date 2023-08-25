using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeImpr.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addedCompanyEmailToHandymanDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CompanyEmail",
                table: "Handymans",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Handymans",
                keyColumn: "Id",
                keyValue: 1,
                column: "CompanyEmail",
                value: "");

            migrationBuilder.UpdateData(
                table: "Handymans",
                keyColumn: "Id",
                keyValue: 2,
                column: "CompanyEmail",
                value: "");

            migrationBuilder.UpdateData(
                table: "Handymans",
                keyColumn: "Id",
                keyValue: 3,
                column: "CompanyEmail",
                value: "");

            migrationBuilder.UpdateData(
                table: "Handymans",
                keyColumn: "Id",
                keyValue: 4,
                column: "CompanyEmail",
                value: "");

            migrationBuilder.UpdateData(
                table: "Handymans",
                keyColumn: "Id",
                keyValue: 5,
                column: "CompanyEmail",
                value: "");

            migrationBuilder.UpdateData(
                table: "Handymans",
                keyColumn: "Id",
                keyValue: 6,
                column: "CompanyEmail",
                value: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanyEmail",
                table: "Handymans");
        }
    }
}
