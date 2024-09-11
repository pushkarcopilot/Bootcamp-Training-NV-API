using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Bootcamp.Data.Migrations
{
    /// <inheritdoc />
    public partial class Init_DB_4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EngagementStatusId",
                table: "Engagements",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AuditType",
                columns: table => new
                {
                    AuditTypeId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditType", x => x.AuditTypeId);
                });

            migrationBuilder.CreateTable(
                name: "AuthUser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthUser", x => x.Id);
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
                name: "UserList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserList", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AuditType",
                columns: new[] { "AuditTypeId", "Name" },
                values: new object[,]
                {
                    { 0, "InternalAudit" },
                    { 1, "ExternalAudit" },
                    { 2, "ComplianceAudit" },
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

            migrationBuilder.AddForeignKey(
                name: "FK_Engagements_AuditType_AuditTypeId",
                table: "Engagements",
                column: "AuditTypeId",
                principalTable: "AuditType",
                principalColumn: "AuditTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Engagements_EngagementStatus_EngagementStatusId",
                table: "Engagements",
                column: "EngagementStatusId",
                principalTable: "EngagementStatus",
                principalColumn: "EngagementStatusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Engagements_AuditType_AuditTypeId",
                table: "Engagements");

            migrationBuilder.DropForeignKey(
                name: "FK_Engagements_EngagementStatus_EngagementStatusId",
                table: "Engagements");

            migrationBuilder.DropTable(
                name: "AuditType");

            migrationBuilder.DropTable(
                name: "AuthUser");

 
            migrationBuilder.DropTable(
                name: "EngagementStatus");

            migrationBuilder.DropTable(
                name: "UserList");

            migrationBuilder.DropIndex(
                name: "IX_Engagements_AuditTypeId",
                table: "Engagements");

            migrationBuilder.DropIndex(
                name: "IX_Engagements_EngagementStatusId",
                table: "Engagements");

            migrationBuilder.DropColumn(
                name: "EngagementStatusId",
                table: "Engagements");
        }
    }
}
