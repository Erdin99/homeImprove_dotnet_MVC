using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeImpr.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addedEmailToHandymanTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Handymans",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Handymans",
                keyColumn: "Id",
                keyValue: 1,
                column: "Email",
                value: "mujo.mujic@gmail.com");

            migrationBuilder.UpdateData(
                table: "Handymans",
                keyColumn: "Id",
                keyValue: 2,
                column: "Email",
                value: "haso.hasic@gmail.com");

            migrationBuilder.UpdateData(
                table: "Handymans",
                keyColumn: "Id",
                keyValue: 3,
                column: "Email",
                value: "djuro.djuric@gmail.com");

            migrationBuilder.UpdateData(
                table: "Handymans",
                keyColumn: "Id",
                keyValue: 4,
                column: "Email",
                value: "pera.peric@gmail.com");

            migrationBuilder.UpdateData(
                table: "Handymans",
                keyColumn: "Id",
                keyValue: 5,
                column: "Email",
                value: "nera.neric@gmail.com");

            migrationBuilder.UpdateData(
                table: "Handymans",
                keyColumn: "Id",
                keyValue: 6,
                column: "Email",
                value: "ramo.ramic@gmail.com");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Handymans");
        }
    }
}
