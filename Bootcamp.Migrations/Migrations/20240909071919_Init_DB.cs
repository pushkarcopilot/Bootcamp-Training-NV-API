using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Bootcamp.Data.Migrations
{
    /// <inheritdoc />
    public partial class Init_DB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuditType",
                columns: table => new
                {
                    AuditTypeId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditType", x => x.AuditTypeId);
                });

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

            migrationBuilder.CreateTable(
                name: "Engagements",
                columns: table => new
                {
                    EngagementId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    AuditTypeId = table.Column<int>(type: "int", nullable: false),
                    AuditStartDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    AuditEndDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    Auditors = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    EngagementStatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Engagements", x => x.EngagementId);
                    table.ForeignKey(
                        name: "FK_Engagements_AuditType_AuditTypeId",
                        column: x => x.AuditTypeId,
                        principalTable: "AuditType",
                        principalColumn: "AuditTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Engagements_EngagementStatus_EngagementStatusId",
                        column: x => x.EngagementStatusId,
                        principalTable: "EngagementStatus",
                        principalColumn: "EngagementStatusId",
                        onDelete: ReferentialAction.Cascade);
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
                name: "IX_Engagements_AuditTypeId",
                table: "Engagements",
                column: "AuditTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Engagements_EngagementStatusId",
                table: "Engagements",
                column: "EngagementStatusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Engagements");

            migrationBuilder.DropTable(
                name: "AuditType");

            migrationBuilder.DropTable(
                name: "EngagementStatus");
        }
    }
}
