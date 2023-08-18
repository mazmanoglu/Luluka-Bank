using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LulukaBankIdentityProject.DataAccessLayer.Migrations
{
    public partial class mig_customeraccounttransaction_add_description : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "CustomerAccountTransactions",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "CustomerAccountTransactions");
        }
    }
}
