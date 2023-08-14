using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeImpr.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addForeignKeyForCategoryHandymanRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Handymans",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Handymans",
                keyColumn: "Id",
                keyValue: 1,
                column: "CategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Handymans",
                keyColumn: "Id",
                keyValue: 2,
                column: "CategoryId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Handymans",
                keyColumn: "Id",
                keyValue: 3,
                column: "CategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Handymans",
                keyColumn: "Id",
                keyValue: 4,
                column: "CategoryId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Handymans",
                keyColumn: "Id",
                keyValue: 5,
                column: "CategoryId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Handymans",
                keyColumn: "Id",
                keyValue: 6,
                column: "CategoryId",
                value: 3);

            migrationBuilder.CreateIndex(
                name: "IX_Handymans_CategoryId",
                table: "Handymans",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Handymans_Categories_CategoryId",
                table: "Handymans",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Handymans_Categories_CategoryId",
                table: "Handymans");

            migrationBuilder.DropIndex(
                name: "IX_Handymans_CategoryId",
                table: "Handymans");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Handymans");
        }
    }
}
