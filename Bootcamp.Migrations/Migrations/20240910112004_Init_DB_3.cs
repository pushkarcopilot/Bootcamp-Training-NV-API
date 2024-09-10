using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bootcamp.Data.Migrations
{
    /// <inheritdoc />
    public partial class Init_DB_3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Engagements_AuditType_AuditTypeId",
                table: "Engagements");

            migrationBuilder.DropTable(
                name: "AuditType");

            migrationBuilder.DropIndex(
                name: "IX_Engagements_AuditTypeId",
                table: "Engagements");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateIndex(
                name: "IX_Engagements_AuditTypeId",
                table: "Engagements",
                column: "AuditTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Engagements_AuditType_AuditTypeId",
                table: "Engagements",
                column: "AuditTypeId",
                principalTable: "AuditType",
                principalColumn: "AuditTypeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
