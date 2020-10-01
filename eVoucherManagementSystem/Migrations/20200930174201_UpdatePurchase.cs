using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eVoucherManagementSystem.Migrations
{
    public partial class UpdatePurchase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EVoucherPaymentModes_EVouchers_eVoucherId",
                table: "EVoucherPaymentModes");

            migrationBuilder.AlterColumn<Guid>(
                name: "eVoucherId",
                table: "PurchaseEVouchers",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CustomerId",
                table: "PurchaseEVouchers",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "PurchaseEVouchers",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<bool>(
                name: "IsUsed",
                table: "PurchaseEVouchers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "EVouchers",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<Guid>(
                name: "eVoucherId",
                table: "EVoucherPaymentModes",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Customers",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_EVoucherPaymentModes_EVouchers_eVoucherId",
                table: "EVoucherPaymentModes",
                column: "eVoucherId",
                principalTable: "EVouchers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EVoucherPaymentModes_EVouchers_eVoucherId",
                table: "EVoucherPaymentModes");

            migrationBuilder.DropColumn(
                name: "IsUsed",
                table: "PurchaseEVouchers");

            migrationBuilder.AlterColumn<string>(
                name: "eVoucherId",
                table: "PurchaseEVouchers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<string>(
                name: "CustomerId",
                table: "PurchaseEVouchers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "PurchaseEVouchers",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "EVouchers",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<string>(
                name: "eVoucherId",
                table: "EVoucherPaymentModes",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Customers",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "FK_EVoucherPaymentModes_EVouchers_eVoucherId",
                table: "EVoucherPaymentModes",
                column: "eVoucherId",
                principalTable: "EVouchers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
