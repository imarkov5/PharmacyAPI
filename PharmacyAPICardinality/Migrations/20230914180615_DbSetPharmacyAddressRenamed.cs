using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PharmacyAPICardinality.Migrations
{
    /// <inheritdoc />
    public partial class DbSetPharmacyAddressRenamed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adresses_Pharmacies_PharmacyId",
                table: "Adresses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Adresses",
                table: "Adresses");

            migrationBuilder.RenameTable(
                name: "Adresses",
                newName: "PharmacyAdresses");

            migrationBuilder.RenameIndex(
                name: "IX_Adresses_PharmacyId",
                table: "PharmacyAdresses",
                newName: "IX_PharmacyAdresses_PharmacyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PharmacyAdresses",
                table: "PharmacyAdresses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PharmacyAdresses_Pharmacies_PharmacyId",
                table: "PharmacyAdresses",
                column: "PharmacyId",
                principalTable: "Pharmacies",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PharmacyAdresses_Pharmacies_PharmacyId",
                table: "PharmacyAdresses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PharmacyAdresses",
                table: "PharmacyAdresses");

            migrationBuilder.RenameTable(
                name: "PharmacyAdresses",
                newName: "Adresses");

            migrationBuilder.RenameIndex(
                name: "IX_PharmacyAdresses_PharmacyId",
                table: "Adresses",
                newName: "IX_Adresses_PharmacyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Adresses",
                table: "Adresses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Adresses_Pharmacies_PharmacyId",
                table: "Adresses",
                column: "PharmacyId",
                principalTable: "Pharmacies",
                principalColumn: "Id");
        }
    }
}
