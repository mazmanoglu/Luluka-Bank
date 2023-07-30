using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LulukaBankIdentityProject.DataAccessLayer.Migrations
{
    public partial class mig_add_customer_relation_process : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReceiverID",
                table: "CustomerAccountTransactions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SenderID",
                table: "CustomerAccountTransactions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAccountTransactions_ReceiverID",
                table: "CustomerAccountTransactions",
                column: "ReceiverID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAccountTransactions_SenderID",
                table: "CustomerAccountTransactions",
                column: "SenderID");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerAccountTransactions_CustomerAccounts_ReceiverID",
                table: "CustomerAccountTransactions",
                column: "ReceiverID",
                principalTable: "CustomerAccounts",
                principalColumn: "CustomerAccountID");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerAccountTransactions_CustomerAccounts_SenderID",
                table: "CustomerAccountTransactions",
                column: "SenderID",
                principalTable: "CustomerAccounts",
                principalColumn: "CustomerAccountID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerAccountTransactions_CustomerAccounts_ReceiverID",
                table: "CustomerAccountTransactions");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerAccountTransactions_CustomerAccounts_SenderID",
                table: "CustomerAccountTransactions");

            migrationBuilder.DropIndex(
                name: "IX_CustomerAccountTransactions_ReceiverID",
                table: "CustomerAccountTransactions");

            migrationBuilder.DropIndex(
                name: "IX_CustomerAccountTransactions_SenderID",
                table: "CustomerAccountTransactions");

            migrationBuilder.DropColumn(
                name: "ReceiverID",
                table: "CustomerAccountTransactions");

            migrationBuilder.DropColumn(
                name: "SenderID",
                table: "CustomerAccountTransactions");
        }
    }
}
