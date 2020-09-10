using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication2.Migrations
{
    public partial class changedChecklist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "checkTask");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Checklist");

            migrationBuilder.AddColumn<bool>(
                name: "Completed",
                table: "Checklist",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Checklist",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DisplayFormat",
                table: "Checklist",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Sequence",
                table: "Checklist",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Completed",
                table: "Checklist");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Checklist");

            migrationBuilder.DropColumn(
                name: "DisplayFormat",
                table: "Checklist");

            migrationBuilder.DropColumn(
                name: "Sequence",
                table: "Checklist");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Checklist",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "checkTask",
                columns: table => new
                {
                    UserTaskId = table.Column<int>(type: "int", nullable: false),
                    ChecklistId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_checkTask", x => new { x.UserTaskId, x.ChecklistId });
                    table.ForeignKey(
                        name: "FK_checkTask_Checklist_ChecklistId",
                        column: x => x.ChecklistId,
                        principalTable: "Checklist",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_checkTask_UserTask_UserTaskId",
                        column: x => x.UserTaskId,
                        principalTable: "UserTask",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_checkTask_ChecklistId",
                table: "checkTask",
                column: "ChecklistId");
        }
    }
}
