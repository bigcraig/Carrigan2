using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication2.Migrations
{
    public partial class changeMeasureID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TemperatureMeasurement_AspNetUsers_ApplicationUserId1",
                table: "TemperatureMeasurement");

            migrationBuilder.DropIndex(
                name: "IX_TemperatureMeasurement_ApplicationUserId1",
                table: "TemperatureMeasurement");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "TemperatureMeasurement");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "TemperatureMeasurement",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_TemperatureMeasurement_ApplicationUserId",
                table: "TemperatureMeasurement",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TemperatureMeasurement_AspNetUsers_ApplicationUserId",
                table: "TemperatureMeasurement",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TemperatureMeasurement_AspNetUsers_ApplicationUserId",
                table: "TemperatureMeasurement");

            migrationBuilder.DropIndex(
                name: "IX_TemperatureMeasurement_ApplicationUserId",
                table: "TemperatureMeasurement");

            migrationBuilder.AlterColumn<int>(
                name: "ApplicationUserId",
                table: "TemperatureMeasurement",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "TemperatureMeasurement",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TemperatureMeasurement_ApplicationUserId1",
                table: "TemperatureMeasurement",
                column: "ApplicationUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_TemperatureMeasurement_AspNetUsers_ApplicationUserId1",
                table: "TemperatureMeasurement",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
