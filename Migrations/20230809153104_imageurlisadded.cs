using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmailWebApplication.Migrations
{
    /// <inheritdoc />
    public partial class imageurlisadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "EmailForms",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "EmailForms",
                keyColumn: "ID",
                keyValue: 1,
                column: "ImageUrl",
                value: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "EmailForms");
        }
    }
}
