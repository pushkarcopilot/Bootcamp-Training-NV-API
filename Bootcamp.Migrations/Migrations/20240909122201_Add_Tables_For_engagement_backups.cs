using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bootcamp.Data.Migrations
{
    /// <inheritdoc />
    public partial class Add_Tables_For_engagement_backups : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EngagementBackups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BackupId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EngagementId = table.Column<int>(type: "int", nullable: false),
                    BackupTimestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClientName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    AuditTypeId = table.Column<int>(type: "int", nullable: false),
                    AuditStartDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    AuditEndDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    Auditors = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EngagementStatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EngagementBackups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EngagementSettings",
                columns: table => new
                {
                    SettingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KeyName = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    DataType = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    ValueBigInt = table.Column<long>(type: "bigint", nullable: true),
                    ValueNumeric = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ValueSmallInt = table.Column<short>(type: "smallint", nullable: true),
                    ValueDecimal = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ValueSmallMoney = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ValueInt = table.Column<int>(type: "int", nullable: true),
                    ValueTinyInt = table.Column<byte>(type: "tinyint", nullable: true),
                    ValueMoney = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ValueFloat = table.Column<float>(type: "real", nullable: true),
                    ValueReal = table.Column<float>(type: "real", nullable: true),
                    ValueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ValueDateTimeOffSet = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ValueDateTime2 = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ValueSmallDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ValueDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ValueTime = table.Column<TimeSpan>(type: "time", nullable: true),
                    ValueVarChar = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    ValueChar = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InsertedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EngagementSettings", x => x.SettingId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EngagementBackups");

            migrationBuilder.DropTable(
                name: "EngagementSettings");
        }
    }
}
