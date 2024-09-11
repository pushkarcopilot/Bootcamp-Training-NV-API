using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootcamp.Migrations
{
    public partial class AuthUser : Migration
    {

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuditUser",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"), // Identity column
                    Role = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false), // Role with max length
                    UserName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false), // UserName with max length
                    IsAuthorized = table.Column<bool>(type: "bit", nullable: false), // Boolean field
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()"), // CreatedDate with default value
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()")  // ModifiedDate with default value
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditUser", x => x.ID); // Primary Key
                });

            // Optionally, if you want to insert initial data into the AuditUser table:
            migrationBuilder.InsertData(
                table: "AuditUser",
                columns: new[] { "ID", "Role", "UserName", "IsAuthorized", "CreatedDate", "ModifiedDate" },
                values: new object[] { 1, "Admin", "AdminUser", true, DateTime.Now, DateTime.Now }
            );

            migrationBuilder.InsertData(
                table: "AuditUser",
                columns: new[] { "ID", "Role", "UserName", "IsAuthorized", "CreatedDate", "ModifiedDate" },
                values: new object[] { 2, "User", "NormalUser", false, DateTime.Now, DateTime.Now }
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuditUser");
        }

    }
}
