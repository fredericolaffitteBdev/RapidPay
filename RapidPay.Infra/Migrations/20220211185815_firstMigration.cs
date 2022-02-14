using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace RapidPay.Infra.Migrations
{
    public partial class firstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Banks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BankId = table.Column<int>(type: "int", nullable: false),
                    BankName = table.Column<string>(type: "varchar(50)", nullable: false),
                    BankAccountNumber = table.Column<int>(type: "int", nullable: false),
                    BankAgencyNumber = table.Column<int>(type: "int", nullable: false),
                    BankAmount = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsCredit = table.Column<bool>(type: "bit", nullable: false),
                    CardNumber = table.Column<string>(type: "varchar(15)", nullable: false),
                    ExpirationDate = table.Column<string>(type: "varchar(50)", nullable: false),
                    CVV = table.Column<int>(type: "int", nullable: false),
                    Balance = table.Column<decimal>(type: "decimal", nullable: false),
                    BalanceUsed = table.Column<decimal>(type: "decimal", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CardNumberPayment = table.Column<string>(type: "varchar(15)", nullable: false),
                    PaymentValue = table.Column<decimal>(type: "decimal", nullable: false),
                    PaymentDate = table.Column<string>(type: "varchar(50)", nullable: false),
                    PaymentDescription = table.Column<string>(type: "varchar(150)", nullable: false),
                    PaymentResult = table.Column<string>(type: "varchar(50)", nullable: false),
                    Receiver = table.Column<string>(type: "varchar(50)", nullable: false),
                    FeeTransaction = table.Column<decimal>(type: "Decimal", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "varchar(50)", nullable: false),
                    Password = table.Column<string>(type: "varchar(50)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Banks");

            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
