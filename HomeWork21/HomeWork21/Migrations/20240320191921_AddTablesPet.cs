using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeWork21.Migrations
{
    /// <inheritdoc />
    public partial class AddTablesPet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Breeds_Categories_CategoryId",
                table: "Breeds");

            migrationBuilder.DropForeignKey(
                name: "FK_Pets_Breeds_BreedId",
                table: "Pets");

            migrationBuilder.DropForeignKey(
                name: "FK_Pets_Categories_CategoryId",
                table: "Pets");

            migrationBuilder.DropForeignKey(
                name: "FK_Pets_Locations_LocationId",
                table: "Pets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pets",
                table: "Pets");

            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.RenameTable(
                name: "Pets",
                newName: "Pet",
                newSchema: "dbo");

            migrationBuilder.RenameIndex(
                name: "IX_Pets_LocationId",
                schema: "dbo",
                table: "Pet",
                newName: "IX_Pet_LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_Pets_CategoryId",
                schema: "dbo",
                table: "Pet",
                newName: "IX_Pet_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Pets_BreedId",
                schema: "dbo",
                table: "Pet",
                newName: "IX_Pet_BreedId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pet",
                schema: "dbo",
                table: "Pet",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Breeds_Categories_CategoryId",
                table: "Breeds",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pet_Breeds_BreedId",
                schema: "dbo",
                table: "Pet",
                column: "BreedId",
                principalTable: "Breeds",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pet_Categories_CategoryId",
                schema: "dbo",
                table: "Pet",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pet_Locations_LocationId",
                schema: "dbo",
                table: "Pet",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Breeds_Categories_CategoryId",
                table: "Breeds");

            migrationBuilder.DropForeignKey(
                name: "FK_Pet_Breeds_BreedId",
                schema: "dbo",
                table: "Pet");

            migrationBuilder.DropForeignKey(
                name: "FK_Pet_Categories_CategoryId",
                schema: "dbo",
                table: "Pet");

            migrationBuilder.DropForeignKey(
                name: "FK_Pet_Locations_LocationId",
                schema: "dbo",
                table: "Pet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pet",
                schema: "dbo",
                table: "Pet");

            migrationBuilder.RenameTable(
                name: "Pet",
                schema: "dbo",
                newName: "Pets");

            migrationBuilder.RenameIndex(
                name: "IX_Pet_LocationId",
                table: "Pets",
                newName: "IX_Pets_LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_Pet_CategoryId",
                table: "Pets",
                newName: "IX_Pets_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Pet_BreedId",
                table: "Pets",
                newName: "IX_Pets_BreedId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pets",
                table: "Pets",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Breeds_Categories_CategoryId",
                table: "Breeds",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_Breeds_BreedId",
                table: "Pets",
                column: "BreedId",
                principalTable: "Breeds",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_Categories_CategoryId",
                table: "Pets",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_Locations_LocationId",
                table: "Pets",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
