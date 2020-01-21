using Microsoft.EntityFrameworkCore.Migrations;

namespace REST_API_Task.Migrations
{
    public partial class ChangeCategoryIDToInteger : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "cat_id",
                table: "Products",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "cat_id",
                table: "Products",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
