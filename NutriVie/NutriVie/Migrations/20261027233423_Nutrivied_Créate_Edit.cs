using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NutriVie.Migrations
{
    /// <inheritdoc />
    public partial class Nutrivied_Créate_Edit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategorieId",
                table: "Categorie",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Categorie",
                keyColumn: "Id",
                keyValue: 1,
                column: "CategorieId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Categorie",
                keyColumn: "Id",
                keyValue: 2,
                column: "CategorieId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Categorie",
                keyColumn: "Id",
                keyValue: 3,
                column: "CategorieId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Categorie",
                keyColumn: "Id",
                keyValue: 4,
                column: "CategorieId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Categorie",
                keyColumn: "Id",
                keyValue: 5,
                column: "CategorieId",
                value: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategorieId",
                table: "Categorie");
        }
    }
}
