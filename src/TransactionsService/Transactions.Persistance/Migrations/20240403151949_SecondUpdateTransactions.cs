using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Transactions.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class SecondUpdateTransactions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Direct",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Transactions");

            migrationBuilder.RenameColumn(
                name: "TransferAmount",
                table: "Transactions",
                newName: "SendAmount");

            migrationBuilder.AddColumn<decimal>(
                name: "ReceiveAmount",
                table: "Transactions",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReceiveAmount",
                table: "Transactions");

            migrationBuilder.RenameColumn(
                name: "SendAmount",
                table: "Transactions",
                newName: "TransferAmount");

            migrationBuilder.AddColumn<int>(
                name: "Direct",
                table: "Transactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Transactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Transactions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
