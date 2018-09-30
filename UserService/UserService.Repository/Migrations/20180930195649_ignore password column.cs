using Microsoft.EntityFrameworkCore.Migrations;

namespace UserService.Repository.Migrations
{
    public partial class ignorepasswordcolumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Users");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Users",
                maxLength: 25,
                nullable: true);
        }
    }
}
