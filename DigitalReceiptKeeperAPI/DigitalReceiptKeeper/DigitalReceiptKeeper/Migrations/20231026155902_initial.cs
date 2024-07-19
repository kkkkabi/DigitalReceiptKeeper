using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitalReceiptKeeper.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QRCodes",
                columns: table => new
                {
                    QRCodeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QRCodeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QRCodeContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QRCodeCategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QRCodeImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QRCodeCreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QRCodes", x => x.QRCodeID);
                });

            migrationBuilder.CreateTable(
                name: "Receipts",
                columns: table => new
                {
                    ReceiptID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StoreName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReceiptDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReceiptFilePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReceiptCategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReceiptNote = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReceiptAmount = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receipts", x => x.ReceiptID);
                });

            migrationBuilder.CreateTable(
                name: "SMSMessages",
                columns: table => new
                {
                    MessageID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TwilioMessageID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MessageContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateReceived = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ContainReceipt = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SMSMessages", x => x.MessageID);
                });

            migrationBuilder.CreateTable(
                name: "TwilioSMS",
                columns: table => new
                {
                    TwilioSMSID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    From = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TwilioSMS", x => x.TwilioSMSID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QRCodes");

            migrationBuilder.DropTable(
                name: "Receipts");

            migrationBuilder.DropTable(
                name: "SMSMessages");

            migrationBuilder.DropTable(
                name: "TwilioSMS");
        }
    }
}
