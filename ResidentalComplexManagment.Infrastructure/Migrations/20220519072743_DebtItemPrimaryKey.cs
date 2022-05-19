using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ResidentalComplexManagment.Infrastructure.Migrations
{
    public partial class DebtItemPrimaryKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResidentDebtItems_Residents_ResidentId",
                table: "ResidentDebtItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ResidentDebtItems",
                table: "ResidentDebtItems");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "ResidentDebtItems",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<string>(
                name: "PaymentItemId",
                table: "ResidentDebtItems",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "ResidentId",
                table: "ResidentDebtItems",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ResidentDebtItems",
                table: "ResidentDebtItems",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ResidentDebtItems_ResidentId",
                table: "ResidentDebtItems",
                column: "ResidentId");

            migrationBuilder.AddForeignKey(
                name: "FK_ResidentDebtItems_Residents_ResidentId",
                table: "ResidentDebtItems",
                column: "ResidentId",
                principalTable: "Residents",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResidentDebtItems_Residents_ResidentId",
                table: "ResidentDebtItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ResidentDebtItems",
                table: "ResidentDebtItems");

            migrationBuilder.DropIndex(
                name: "IX_ResidentDebtItems_ResidentId",
                table: "ResidentDebtItems");

            migrationBuilder.AlterColumn<string>(
                name: "ResidentId",
                table: "ResidentDebtItems",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PaymentItemId",
                table: "ResidentDebtItems",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "ResidentDebtItems",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ResidentDebtItems",
                table: "ResidentDebtItems",
                columns: new[] { "ResidentId", "PaymentItemId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ResidentDebtItems_Residents_ResidentId",
                table: "ResidentDebtItems",
                column: "ResidentId",
                principalTable: "Residents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
