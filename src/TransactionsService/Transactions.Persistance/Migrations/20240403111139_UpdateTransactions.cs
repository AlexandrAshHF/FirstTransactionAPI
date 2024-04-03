using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Transactions.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTransactions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Currency",
                table: "Transactions");

            migrationBuilder.AddColumn<int>(
                name: "CurrencySender",
                table: "Transactions",
                nullable: false,
                type: "int");

            migrationBuilder.AddColumn<int>(
                name: "CurrencyConsumer",
                table: "Transactions",
                nullable: false,
                type: "int");
        }
    }
}
