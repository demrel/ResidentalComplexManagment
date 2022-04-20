using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ResidentalComplexManagment.Infrastructure.Migrations
{
    public partial class DetItemSystem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppartmentDebts");

            migrationBuilder.DropTable(
                name: "PaymentCoefficients");

            migrationBuilder.CreateTable(
                name: "DebtItems",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    From = table.Column<DateOnly>(type: "date", nullable: true),
                    To = table.Column<DateOnly>(type: "date", nullable: true),
                    IsComplusory = table.Column<bool>(type: "boolean", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DebtItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ResidentDebt",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<decimal>(type: "numeric", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    ResidentId = table.Column<string>(type: "text", nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResidentDebt", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResidentDebt_Residents_ResidentId",
                        column: x => x.ResidentId,
                        principalTable: "Residents",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CalculationValues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    From = table.Column<decimal>(type: "numeric", nullable: false),
                    To = table.Column<decimal>(type: "numeric", nullable: false),
                    Value = table.Column<decimal>(type: "numeric", nullable: false),
                    Method = table.Column<int>(type: "integer", nullable: false),
                    PaymentItemId = table.Column<string>(type: "text", nullable: true),
                    IsCurrent = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalculationValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CalculationValues_DebtItems_PaymentItemId",
                        column: x => x.PaymentItemId,
                        principalTable: "DebtItems",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ResidentDebtItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ResidentId = table.Column<string>(type: "text", nullable: true),
                    PaymentItemId = table.Column<string>(type: "text", nullable: true),
                    DiscountPercent = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResidentDebtItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResidentDebtItems_DebtItems_PaymentItemId",
                        column: x => x.PaymentItemId,
                        principalTable: "DebtItems",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ResidentDebtItems_Residents_ResidentId",
                        column: x => x.ResidentId,
                        principalTable: "Residents",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CalculationValues_PaymentItemId",
                table: "CalculationValues",
                column: "PaymentItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ResidentDebt_ResidentId",
                table: "ResidentDebt",
                column: "ResidentId");

            migrationBuilder.CreateIndex(
                name: "IX_ResidentDebtItems_PaymentItemId",
                table: "ResidentDebtItems",
                column: "PaymentItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ResidentDebtItems_ResidentId",
                table: "ResidentDebtItems",
                column: "ResidentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CalculationValues");

            migrationBuilder.DropTable(
                name: "ResidentDebt");

            migrationBuilder.DropTable(
                name: "ResidentDebtItems");

            migrationBuilder.DropTable(
                name: "DebtItems");

            migrationBuilder.CreateTable(
                name: "PaymentCoefficients",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true),
                    Note = table.Column<string>(type: "text", nullable: true),
                    Value = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentCoefficients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppartmentDebts",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    AppartmentId = table.Column<string>(type: "text", nullable: true),
                    PaymentCoefficientId = table.Column<string>(type: "text", nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true),
                    Value = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppartmentDebts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppartmentDebts_Appartments_AppartmentId",
                        column: x => x.AppartmentId,
                        principalTable: "Appartments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppartmentDebts_PaymentCoefficients_PaymentCoefficientId",
                        column: x => x.PaymentCoefficientId,
                        principalTable: "PaymentCoefficients",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppartmentDebts_AppartmentId",
                table: "AppartmentDebts",
                column: "AppartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_AppartmentDebts_PaymentCoefficientId",
                table: "AppartmentDebts",
                column: "PaymentCoefficientId");
        }
    }
}
