using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RPA_Queue.Migrations
{
    public partial class AddItemsToDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RPAQueue",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectName = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Group = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Department = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    CostCenter = table.Column<int>(type: "int", nullable: true),
                    ProcessOwner = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    Account = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    LicenseType = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DevelopmentStatus = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Schedule = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    RunningTimes = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    UsedApps = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    DevelopedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RPAQueue", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RPAQueue");
        }
    }
}
