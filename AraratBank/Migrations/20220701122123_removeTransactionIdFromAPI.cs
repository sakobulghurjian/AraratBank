using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AraratBank.Migrations
{
    public partial class removeTransactionIdFromAPI : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TransactionId",
                table: "APIs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TransactionId",
                table: "APIs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
