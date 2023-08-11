using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmailWebApplication.Migrations
{
    /// <inheritdoc />
    public partial class addedpassword : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "EmailForms",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "EmailForms",
                keyColumn: "ID",
                keyValue: 1,
                column: "Password",
                value: "1234");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "EmailForms");
        }
    }
}
