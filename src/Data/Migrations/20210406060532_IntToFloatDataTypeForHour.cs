using Microsoft.EntityFrameworkCore.Migrations;

namespace Boundless.Data.Migrations
{
    public partial class IntToFloatDataTypeForHour : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "TimeSheetMaster",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<float>(
                name: "TotalHours",
                table: "TimeSheetMaster",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "Hours",
                table: "TimeSheetDetail",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "TimeSheetMaster",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TotalHours",
                table: "TimeSheetMaster",
                nullable: true,
                oldClrType: typeof(float),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Hours",
                table: "TimeSheetDetail",
                nullable: true,
                oldClrType: typeof(float),
                oldNullable: true);
        }
    }
}
