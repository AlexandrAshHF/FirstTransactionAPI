using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Transactions.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class Updatecardandtransactions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Direct",
                table: "Transactions",
                nullable: false,
                type: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeOfCreate",
                table: "Transactions",
                nullable: false,
                type: "datetime2");
        }
    }
}
