using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication2.Migrations
{
    public partial class taskChecklistJoin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Checklist_UserTask_UserTaskID",
                table: "Checklist");

            migrationBuilder.DropIndex(
                name: "IX_Checklist_UserTaskID",
                table: "Checklist");

            migrationBuilder.DropColumn(
                name: "UserTaskID",
                table: "Checklist");

            migrationBuilder.CreateTable(
                name: "checkTask",
                columns: table => new
                {
                    UserTaskId = table.Column<int>(nullable: false),
                    ChecklistId = table.Column<int>(nullable: false)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "checkTask");

            migrationBuilder.AddColumn<int>(
                name: "UserTaskID",
                table: "Checklist",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Checklist_UserTaskID",
                table: "Checklist",
                column: "UserTaskID");

            migrationBuilder.AddForeignKey(
                name: "FK_Checklist_UserTask_UserTaskID",
                table: "Checklist",
                column: "UserTaskID",
                principalTable: "UserTask",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
