using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace TodoApp.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable("TaskLists", table => new
            {
                TaskListId = table.Column<int>(nullable: false).Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                Name = table.Column<string>(nullable: false),
                Active = table.Column<bool>(nullable: false, defaultValue: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_TaskLists", x => x.TaskListId);
            });

            migrationBuilder.CreateTable("Tasks", table => new
            {
                TaskId = table.Column<int>(nullable: false).Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                Name = table.Column<string>(nullable: false),
                Description = table.Column<string>(nullable: true),
                CreatedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "GETUTCDATE()"),
                UpdatedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "GETUTCDATE()"),
                FinishedAt = table.Column<DateTime>(nullable: true),
                ParentId = table.Column<int>(nullable: true),
                TaskListId = table.Column<int>(nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Tasks", x => x.TaskId);
                table.ForeignKey(
                name: "FK_Tasks_Tasklist_TaskListId",
                column: x => x.TaskListId,
                principalTable: "TaskLists",
                principalColumn: "TaskListId",
                onDelete: ReferentialAction.Cascade);
            });

            migrationBuilder.CreateTable("Comments", table => new
            {
                CommentId = table.Column<int>(nullable: false).Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                Text = table.Column<string>(nullable: false),
                CreatedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "GETUTCDATE()"),
                UpdatedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "GETUTCDATE()"),
                TaskId = table.Column<int>(nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Comments", x => x.CommentId);
                table.ForeignKey(
                    name: "FK_Comments_Task_TaskId",
                    column: x => x.TaskId,
                    principalTable: "Tasks",
                    principalColumn: "TaskId",
                    onDelete: ReferentialAction.Cascade);
            });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
