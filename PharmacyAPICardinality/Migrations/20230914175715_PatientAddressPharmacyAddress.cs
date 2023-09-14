using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PharmacyAPICardinality.Migrations
{
    /// <inheritdoc />
    public partial class PatientAddressPharmacyAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Adresses_AddressId",
                table: "Patients");

            migrationBuilder.RenameColumn(
                name: "AddressId",
                table: "Patients",
                newName: "PatientAddressId");

            migrationBuilder.RenameIndex(
                name: "IX_Patients_AddressId",
                table: "Patients",
                newName: "IX_Patients_PatientAddressId");

            migrationBuilder.CreateTable(
                name: "PatientAddress",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Zip = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientAddress", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_PatientAddress_PatientAddressId",
                table: "Patients",
                column: "PatientAddressId",
                principalTable: "PatientAddress",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_PatientAddress_PatientAddressId",
                table: "Patients");

            migrationBuilder.DropTable(
                name: "PatientAddress");

            migrationBuilder.RenameColumn(
                name: "PatientAddressId",
                table: "Patients",
                newName: "AddressId");

            migrationBuilder.RenameIndex(
                name: "IX_Patients_PatientAddressId",
                table: "Patients",
                newName: "IX_Patients_AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Adresses_AddressId",
                table: "Patients",
                column: "AddressId",
                principalTable: "Adresses",
                principalColumn: "Id");
        }
    }
}
