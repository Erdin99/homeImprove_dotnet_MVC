using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeImpr.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class translatedCategoryNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "DisplayOrder",
                table: "Categories",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Electrician");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Ceramist");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Carpenter");

            migrationBuilder.UpdateData(
                table: "Handymans",
                keyColumn: "Id",
                keyValue: 1,
                column: "Title",
                value: "Electrician");

            migrationBuilder.UpdateData(
                table: "Handymans",
                keyColumn: "Id",
                keyValue: 2,
                column: "Title",
                value: "Carpenter");

            migrationBuilder.UpdateData(
                table: "Handymans",
                keyColumn: "Id",
                keyValue: 3,
                column: "Title",
                value: "Electrician");

            migrationBuilder.UpdateData(
                table: "Handymans",
                keyColumn: "Id",
                keyValue: 4,
                column: "Title",
                value: "Ceramist");

            migrationBuilder.UpdateData(
                table: "Handymans",
                keyColumn: "Id",
                keyValue: 5,
                column: "Title",
                value: "Ceramist");

            migrationBuilder.UpdateData(
                table: "Handymans",
                keyColumn: "Id",
                keyValue: 6,
                column: "Title",
                value: "Carpenter");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "DisplayOrder",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Električar");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Keramičar");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Stolar");

            migrationBuilder.UpdateData(
                table: "Handymans",
                keyColumn: "Id",
                keyValue: 1,
                column: "Title",
                value: "Električar");

            migrationBuilder.UpdateData(
                table: "Handymans",
                keyColumn: "Id",
                keyValue: 2,
                column: "Title",
                value: "Stolar");

            migrationBuilder.UpdateData(
                table: "Handymans",
                keyColumn: "Id",
                keyValue: 3,
                column: "Title",
                value: "Električar");

            migrationBuilder.UpdateData(
                table: "Handymans",
                keyColumn: "Id",
                keyValue: 4,
                column: "Title",
                value: "Keramičar");

            migrationBuilder.UpdateData(
                table: "Handymans",
                keyColumn: "Id",
                keyValue: 5,
                column: "Title",
                value: "Keramičar");

            migrationBuilder.UpdateData(
                table: "Handymans",
                keyColumn: "Id",
                keyValue: 6,
                column: "Title",
                value: "Stolar");
        }
    }
}
