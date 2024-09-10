using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Bootcamp.Data.Migrations
{
    /// <inheritdoc />
    public partial class Init_DB_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Engagements_EngagementStatus_EngagementStatusId",
                table: "Engagements");

            migrationBuilder.DropTable(
                name: "EngagementStatus");

            migrationBuilder.DropIndex(
                name: "IX_Engagements_EngagementStatusId",
                table: "Engagements");

            migrationBuilder.DeleteData(
                table: "AuditType",
                keyColumn: "AuditTypeId",
                keyValue: 0);

            migrationBuilder.DeleteData(
                table: "AuditType",
                keyColumn: "AuditTypeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AuditType",
                keyColumn: "AuditTypeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AuditType",
                keyColumn: "AuditTypeId",
                keyValue: 3);

            migrationBuilder.RenameColumn(
                name: "EngagementStatusId",
                table: "Engagements",
                newName: "StatusId");

            migrationBuilder.AlterColumn<string>(
                name: "ClientName",
                table: "Engagements",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Auditors",
                table: "Engagements",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AuditType",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StatusId",
                table: "Engagements",
                newName: "EngagementStatusId");

            migrationBuilder.AlterColumn<string>(
                name: "ClientName",
                table: "Engagements",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Auditors",
                table: "Engagements",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AuditType",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "EngagementStatus",
                columns: table => new
                {
                    EngagementStatusId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EngagementStatus", x => x.EngagementStatusId);
                });

            migrationBuilder.InsertData(
                table: "AuditType",
                columns: new[] { "AuditTypeId", "Name" },
                values: new object[,]
                {
                    { 0, "InternalAudit" },
                    { 1, "ExternalAudit" },
                    { 2, "IRSTaxAudit" },
                    { 3, "FinancialAudit" }
                });

            migrationBuilder.InsertData(
                table: "EngagementStatus",
                columns: new[] { "EngagementStatusId", "Name" },
                values: new object[,]
                {
                    { 0, "NotStarted" },
                    { 1, "Assigned" },
                    { 2, "InProgress" },
                    { 3, "Completed" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Engagements_EngagementStatusId",
                table: "Engagements",
                column: "EngagementStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Engagements_EngagementStatus_EngagementStatusId",
                table: "Engagements",
                column: "EngagementStatusId",
                principalTable: "EngagementStatus",
                principalColumn: "EngagementStatusId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
