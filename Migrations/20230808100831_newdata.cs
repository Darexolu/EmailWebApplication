using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmailWebApplication.Migrations
{
    /// <inheritdoc />
    public partial class newdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "EmailForms",
                columns: new[] { "ID", "Email", "FirstName", "Gender", "LastName" },
                values: new object[] { 1, "darexolu16@gmail.com", "Dare", "Male", "Seun" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EmailForms",
                keyColumn: "ID",
                keyValue: 1);
        }
    }
}
