using Microsoft.EntityFrameworkCore.Migrations;

namespace Boundless.Data.Migrations
{
    public partial class UserIdToStringDatatype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "TimeSheetDetail",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Employee",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Employee");

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "TimeSheetDetail",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
