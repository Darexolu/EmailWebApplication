using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmailWebApplication.Migrations
{
    /// <inheritdoc />
    public partial class addedfullname : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "EmailForms");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "EmailForms");

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "EmailForms",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "EmailForms",
                keyColumn: "ID",
                keyValue: 1,
                column: "FullName",
                value: "Olushola Damilare");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullName",
                table: "EmailForms");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "EmailForms",
                type: "TEXT",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "EmailForms",
                type: "TEXT",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "EmailForms",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Dare", "Seun" });
        }
    }
}
