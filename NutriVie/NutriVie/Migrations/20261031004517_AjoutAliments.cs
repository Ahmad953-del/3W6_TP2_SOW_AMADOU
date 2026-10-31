using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NutriVie.Migrations
{
    /// <inheritdoc />
    public partial class AjoutAliments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlimentRecette_Aliment_AlimentId",
                table: "AlimentRecette");

            migrationBuilder.DropForeignKey(
                name: "FK_AlimentRecette_Recettes_RecetteId",
                table: "AlimentRecette");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AlimentRecette",
                table: "AlimentRecette");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Aliment",
                table: "Aliment");

            migrationBuilder.RenameTable(
                name: "AlimentRecette",
                newName: "AlimentRecettes");

            migrationBuilder.RenameTable(
                name: "Aliment",
                newName: "Aliments");

            migrationBuilder.RenameIndex(
                name: "IX_AlimentRecette_AlimentId",
                table: "AlimentRecettes",
                newName: "IX_AlimentRecettes_AlimentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AlimentRecettes",
                table: "AlimentRecettes",
                columns: new[] { "RecetteId", "AlimentId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Aliments",
                table: "Aliments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AlimentRecettes_Aliments_AlimentId",
                table: "AlimentRecettes",
                column: "AlimentId",
                principalTable: "Aliments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AlimentRecettes_Recettes_RecetteId",
                table: "AlimentRecettes",
                column: "RecetteId",
                principalTable: "Recettes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlimentRecettes_Aliments_AlimentId",
                table: "AlimentRecettes");

            migrationBuilder.DropForeignKey(
                name: "FK_AlimentRecettes_Recettes_RecetteId",
                table: "AlimentRecettes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Aliments",
                table: "Aliments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AlimentRecettes",
                table: "AlimentRecettes");

            migrationBuilder.RenameTable(
                name: "Aliments",
                newName: "Aliment");

            migrationBuilder.RenameTable(
                name: "AlimentRecettes",
                newName: "AlimentRecette");

            migrationBuilder.RenameIndex(
                name: "IX_AlimentRecettes_AlimentId",
                table: "AlimentRecette",
                newName: "IX_AlimentRecette_AlimentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Aliment",
                table: "Aliment",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AlimentRecette",
                table: "AlimentRecette",
                columns: new[] { "RecetteId", "AlimentId" });

            migrationBuilder.AddForeignKey(
                name: "FK_AlimentRecette_Aliment_AlimentId",
                table: "AlimentRecette",
                column: "AlimentId",
                principalTable: "Aliment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AlimentRecette_Recettes_RecetteId",
                table: "AlimentRecette",
                column: "RecetteId",
                principalTable: "Recettes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
