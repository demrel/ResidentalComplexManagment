using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResidentalComplexManagment.Infrastructure.Migrations
{
    public partial class PaymentCoficient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Birthday",
                table: "Residents",
                type: "Date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "PaymentCoefficients",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Note",
                table: "PaymentCoefficients");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Birthday",
                table: "Residents",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "Date",
                oldNullable: true);
        }
    }
}
