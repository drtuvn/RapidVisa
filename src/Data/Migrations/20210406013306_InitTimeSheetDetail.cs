using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Boundless.Data.Migrations
{
    public partial class InitTimeSheetDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProjectMaster",
                columns: table => new
                {
                    ProjectID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProjectCode = table.Column<string>(nullable: false),
                    NatureofIndustry = table.Column<string>(nullable: false),
                    ProjectName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectMaster", x => x.ProjectID);
                });

            migrationBuilder.CreateTable(
                name: "TaskMaster",
                columns: table => new
                {
                    TaskID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProjectCode = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskMaster", x => x.TaskID);
                });

            migrationBuilder.CreateTable(
                name: "TimeSheetDetail",
                columns: table => new
                {
                    TimeSheetID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DaysofWeek = table.Column<string>(nullable: true),
                    Hours = table.Column<int>(nullable: true),
                    Period = table.Column<DateTime>(nullable: true),
                    ProjectID = table.Column<int>(nullable: true),
                    UserID = table.Column<int>(nullable: false),
                    TaskID = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    TimeSheetMasterID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeSheetDetail", x => x.TimeSheetID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectMaster");

            migrationBuilder.DropTable(
                name: "TaskMaster");

            migrationBuilder.DropTable(
                name: "TimeSheetDetail");
        }
    }
}
