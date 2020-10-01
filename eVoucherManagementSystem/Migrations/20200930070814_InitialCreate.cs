using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eVoucherManagementSystem.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    PhoneNo = table.Column<string>(nullable: true),
                    MaxCanBuyeVoucher = table.Column<int>(nullable: false),
                    GiftPerUserBuy = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EVouchers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ExpiryDate = table.Column<DateTime>(nullable: false),
                    ImageURL = table.Column<string>(nullable: true),
                    Amount = table.Column<decimal>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    BuyType = table.Column<int>(nullable: false),
                    MaxCanBuyeVoucher = table.Column<int>(nullable: false),
                    GiftPerUserBuy = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    EVoucherStatus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EVouchers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentModes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentType = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    isActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentModes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseEVouchers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    eVoucherId = table.Column<string>(nullable: true),
                    CustomerId = table.Column<string>(nullable: true),
                    Qty = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseEVouchers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EVoucherPaymentModes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentModeId = table.Column<int>(nullable: false),
                    PaymentType = table.Column<string>(nullable: true),
                    eVoucherId = table.Column<string>(nullable: true),
                    Discount = table.Column<decimal>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EVoucherPaymentModes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EVoucherPaymentModes_EVouchers_eVoucherId",
                        column: x => x.eVoucherId,
                        principalTable: "EVouchers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EVoucherPaymentModes_eVoucherId",
                table: "EVoucherPaymentModes",
                column: "eVoucherId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "EVoucherPaymentModes");

            migrationBuilder.DropTable(
                name: "PaymentModes");

            migrationBuilder.DropTable(
                name: "PurchaseEVouchers");

            migrationBuilder.DropTable(
                name: "EVouchers");
        }
    }
}
