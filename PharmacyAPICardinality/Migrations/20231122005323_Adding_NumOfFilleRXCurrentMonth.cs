using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PharmacyAPICardinality.Migrations
{
    /// <inheritdoc />
    public partial class Adding_NumOfFilleRXCurrentMonth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumOfFilledRxCurrentMonth",
                table: "Pharmacy",
                type: "int",
                nullable: true,
                computedColumnSql: "([dbo].[countFilledRxCurrentMonth]([Id]))",
                stored: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumOfFilledRxCurrentMonth",
                table: "Pharmacy");
        }
    }
}
