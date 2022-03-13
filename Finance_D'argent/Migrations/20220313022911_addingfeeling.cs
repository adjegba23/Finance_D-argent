using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Finance_D_argent.Migrations
{
    public partial class addingfeeling : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Reason",
                table: "Journal_Accounts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Reason",
                table: "Journal_Accounts");
        }
    }
}
