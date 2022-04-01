using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResidentalComplexManagment.Infrastructure.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MKTs",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    IBAN = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MKTs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Nottifications",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Text = table.Column<string>(type: "text", nullable: true),
                    Sender = table.Column<string>(type: "text", nullable: true),
                    IsAutomatic = table.Column<bool>(type: "boolean", nullable: false),
                    AutomaticSendingPeriod = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nottifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentCoefficients",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<decimal>(type: "numeric", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentCoefficients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Buildings",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Number = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    MKTId = table.Column<string>(type: "text", nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buildings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Buildings_MKTs_MKTId",
                        column: x => x.MKTId,
                        principalTable: "MKTs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Appartments",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    DoorNumber = table.Column<int>(type: "integer", nullable: false),
                    Area = table.Column<decimal>(type: "numeric", nullable: false),
                    BuildingId = table.Column<string>(type: "text", nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appartments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appartments_Buildings_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "Buildings",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AppartmentDebts",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<decimal>(type: "numeric", nullable: false),
                    AppartmentId = table.Column<string>(type: "text", nullable: true),
                    PaymentCoefficientId = table.Column<string>(type: "text", nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true)
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

            migrationBuilder.CreateTable(
                name: "Residents",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Surname = table.Column<string>(type: "text", nullable: true),
                    FIN = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    Birthday = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsCurrentResident = table.Column<bool>(type: "boolean", nullable: false),
                    AppartmentId = table.Column<string>(type: "text", nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Residents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Residents_Appartments_AppartmentId",
                        column: x => x.AppartmentId,
                        principalTable: "Appartments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "NottificationResident",
                columns: table => new
                {
                    NottificationsId = table.Column<string>(type: "text", nullable: false),
                    RecipientsId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NottificationResident", x => new { x.NottificationsId, x.RecipientsId });
                    table.ForeignKey(
                        name: "FK_NottificationResident_Nottifications_NottificationsId",
                        column: x => x.NottificationsId,
                        principalTable: "Nottifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NottificationResident_Residents_RecipientsId",
                        column: x => x.RecipientsId,
                        principalTable: "Residents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResidentPayments",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<decimal>(type: "numeric", nullable: false),
                    Detail = table.Column<string>(type: "text", nullable: true),
                    TransactionId = table.Column<string>(type: "text", nullable: true),
                    ResidentId = table.Column<string>(type: "text", nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResidentPayments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResidentPayments_Residents_ResidentId",
                        column: x => x.ResidentId,
                        principalTable: "Residents",
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

            migrationBuilder.CreateIndex(
                name: "IX_Appartments_BuildingId",
                table: "Appartments",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_Buildings_MKTId",
                table: "Buildings",
                column: "MKTId");

            migrationBuilder.CreateIndex(
                name: "IX_NottificationResident_RecipientsId",
                table: "NottificationResident",
                column: "RecipientsId");

            migrationBuilder.CreateIndex(
                name: "IX_ResidentPayments_ResidentId",
                table: "ResidentPayments",
                column: "ResidentId");

            migrationBuilder.CreateIndex(
                name: "IX_Residents_AppartmentId",
                table: "Residents",
                column: "AppartmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppartmentDebts");

            migrationBuilder.DropTable(
                name: "NottificationResident");

            migrationBuilder.DropTable(
                name: "ResidentPayments");

            migrationBuilder.DropTable(
                name: "PaymentCoefficients");

            migrationBuilder.DropTable(
                name: "Nottifications");

            migrationBuilder.DropTable(
                name: "Residents");

            migrationBuilder.DropTable(
                name: "Appartments");

            migrationBuilder.DropTable(
                name: "Buildings");

            migrationBuilder.DropTable(
                name: "MKTs");
        }
    }
}
