using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

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
                CreatedAt = table.Column<string>(nullable: false),
                UpdatedAt = table.Column<string>(nullable: false),
                FinishedAt = table.Column<string>(nullable: true),
                ParentId = table.Column<int>(nullable: true),
                TaskListId = table.Column<int>(nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Tasks", x => x.TaskId);
            });

            migrationBuilder.CreateTable("Comments", table => new
            {
                CommentId = table.Column<int>(nullable: false).Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                Text = table.Column<string>(nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Comments", x => x.CommentId);
            });

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
