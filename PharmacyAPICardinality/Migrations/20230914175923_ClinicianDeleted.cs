using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PharmacyAPICardinality.Migrations
{
    /// <inheritdoc />
    public partial class ClinicianDeleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prescriptions_Clinicians_ClinicianId",
                table: "Prescriptions");

            migrationBuilder.DropTable(
                name: "Clinicians");

            migrationBuilder.DropIndex(
                name: "IX_Prescriptions_ClinicianId",
                table: "Prescriptions");

            migrationBuilder.DropColumn(
                name: "ClinicianId",
                table: "Prescriptions");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClinicianId",
                table: "Prescriptions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Clinicians",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dea_number = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clinicians", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_ClinicianId",
                table: "Prescriptions",
                column: "ClinicianId");

            migrationBuilder.AddForeignKey(
                name: "FK_Prescriptions_Clinicians_ClinicianId",
                table: "Prescriptions",
                column: "ClinicianId",
                principalTable: "Clinicians",
                principalColumn: "Id");
        }
    }
}
