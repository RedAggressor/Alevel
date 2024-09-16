using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeWork21.Migrations
{
    /// <inheritdoc />
    public partial class ColumName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "LocationId",
                schema: "dbo",
                table: "Pet",
                newName: "Location_Id");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                schema: "dbo",
                table: "Pet",
                newName: "Category_Id");

            migrationBuilder.RenameColumn(
                name: "BreedId",
                schema: "dbo",
                table: "Pet",
                newName: "Breed_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Pet_LocationId",
                schema: "dbo",
                table: "Pet",
                newName: "IX_Pet_Location_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Pet_CategoryId",
                schema: "dbo",
                table: "Pet",
                newName: "IX_Pet_Category_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Pet_BreedId",
                schema: "dbo",
                table: "Pet",
                newName: "IX_Pet_Breed_Id");

            migrationBuilder.RenameColumn(
                name: "breed_name",
                table: "Breeds",
                newName: "Breed_name");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Breeds",
                newName: "Category_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Breeds_CategoryId",
                table: "Breeds",
                newName: "IX_Breeds_Category_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Breeds_Categories_Category_Id",
                table: "Breeds",
                column: "Category_Id",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pet_Breeds_Breed_Id",
                schema: "dbo",
                table: "Pet",
                column: "Breed_Id",
                principalTable: "Breeds",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pet_Categories_Category_Id",
                schema: "dbo",
                table: "Pet",
                column: "Category_Id",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pet_Locations_Location_Id",
                schema: "dbo",
                table: "Pet",
                column: "Location_Id",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Breeds_Categories_Category_Id",
                table: "Breeds");

            migrationBuilder.DropForeignKey(
                name: "FK_Pet_Breeds_Breed_Id",
                schema: "dbo",
                table: "Pet");

            migrationBuilder.DropForeignKey(
                name: "FK_Pet_Categories_Category_Id",
                schema: "dbo",
                table: "Pet");

            migrationBuilder.DropForeignKey(
                name: "FK_Pet_Locations_Location_Id",
                schema: "dbo",
                table: "Pet");

            migrationBuilder.RenameColumn(
                name: "Location_Id",
                schema: "dbo",
                table: "Pet",
                newName: "LocationId");

            migrationBuilder.RenameColumn(
                name: "Category_Id",
                schema: "dbo",
                table: "Pet",
                newName: "CategoryId");

            migrationBuilder.RenameColumn(
                name: "Breed_Id",
                schema: "dbo",
                table: "Pet",
                newName: "BreedId");

            migrationBuilder.RenameIndex(
                name: "IX_Pet_Location_Id",
                schema: "dbo",
                table: "Pet",
                newName: "IX_Pet_LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_Pet_Category_Id",
                schema: "dbo",
                table: "Pet",
                newName: "IX_Pet_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Pet_Breed_Id",
                schema: "dbo",
                table: "Pet",
                newName: "IX_Pet_BreedId");

            migrationBuilder.RenameColumn(
                name: "Breed_name",
                table: "Breeds",
                newName: "breed_name");

            migrationBuilder.RenameColumn(
                name: "Category_Id",
                table: "Breeds",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Breeds_Category_Id",
                table: "Breeds",
                newName: "IX_Breeds_CategoryId");

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
    }
}
