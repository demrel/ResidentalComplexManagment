using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ResidentalComplexManagment.Infrastructure.Migrations
{
    public partial class ResidentPromotion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResidentDebtItems_DebtItems_PaymentItemId",
                table: "ResidentDebtItems");

            migrationBuilder.DropIndex(
                name: "IX_ResidentDebtItems_PaymentItemId",
                table: "ResidentDebtItems");

            migrationBuilder.DropColumn(
                name: "DiscountPercent",
                table: "ResidentDebtItems");

            migrationBuilder.AddColumn<DateOnly>(
                name: "EndDate",
                table: "ResidentDebtItems",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "ResidentDebtItems",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateOnly>(
                name: "StartDate",
                table: "ResidentDebtItems",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.CreateTable(
                name: "ResidentDebtItemDiscount",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ResidentId = table.Column<string>(type: "text", nullable: true),
                    PaymentItemId = table.Column<string>(type: "text", nullable: true),
                    DiscountPercent = table.Column<decimal>(type: "numeric", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResidentDebtItemDiscount", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResidentDebtItemDiscount_Residents_ResidentId",
                        column: x => x.ResidentId,
                        principalTable: "Residents",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ResidentDebtItemDiscount_ResidentId",
                table: "ResidentDebtItemDiscount",
                column: "ResidentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResidentDebtItemDiscount");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "ResidentDebtItems");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "ResidentDebtItems");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "ResidentDebtItems");

            migrationBuilder.AddColumn<decimal>(
                name: "DiscountPercent",
                table: "ResidentDebtItems",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_ResidentDebtItems_PaymentItemId",
                table: "ResidentDebtItems",
                column: "PaymentItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_ResidentDebtItems_DebtItems_PaymentItemId",
                table: "ResidentDebtItems",
                column: "PaymentItemId",
                principalTable: "DebtItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
