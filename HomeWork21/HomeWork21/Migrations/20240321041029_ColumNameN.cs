using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeWork21.Migrations
{
    /// <inheritdoc />
    public partial class ColumNameN : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Breed_name",
                table: "Breeds",
                newName: "Breed_Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Breed_Name",
                table: "Breeds",
                newName: "Breed_name");
        }
    }
}
