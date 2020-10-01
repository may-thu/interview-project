using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eVoucherManagementSystem.Migrations
{
    public partial class CreateQRCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QRCodes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    eVoucherId = table.Column<Guid>(nullable: false),
                    QRCodeImg = table.Column<byte[]>(nullable: true),
                    PromoCode = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QRCodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QRCodes_EVouchers_eVoucherId",
                        column: x => x.eVoucherId,
                        principalTable: "EVouchers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QRCodes_eVoucherId",
                table: "QRCodes",
                column: "eVoucherId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QRCodes");
        }
    }
}
