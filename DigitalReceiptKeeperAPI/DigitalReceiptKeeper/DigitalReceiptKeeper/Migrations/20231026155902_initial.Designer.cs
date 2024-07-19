﻿// <auto-generated />
using System;
using DigitalReceiptKeeper.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DigitalReceiptKeeper.Migrations
{
    [DbContext(typeof(DigitalReceiptKeeperDbContext))]
    [Migration("20231026155902_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DigitalReceiptKeeper.Models.QRCode", b =>
                {
                    b.Property<Guid>("QRCodeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("QRCodeCategory")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("QRCodeContent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("QRCodeCreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("QRCodeImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("QRCodeName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("QRCodeID");

                    b.ToTable("QRCodes");
                });

            modelBuilder.Entity("DigitalReceiptKeeper.Models.Receipt", b =>
                {
                    b.Property<Guid>("ReceiptID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ReceiptAmount")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReceiptCategory")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReceiptDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReceiptFilePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReceiptNote")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StoreName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ReceiptID");

                    b.ToTable("Receipts");
                });

            modelBuilder.Entity("DigitalReceiptKeeper.Models.SMSMessage", b =>
                {
                    b.Property<Guid>("MessageID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("ContainReceipt")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DateReceived")
                        .HasColumnType("datetime2");

                    b.Property<string>("MessageContent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TwilioMessageID")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MessageID");

                    b.ToTable("SMSMessages");
                });

            modelBuilder.Entity("DigitalReceiptKeeper.Models.TwilioSMS", b =>
                {
                    b.Property<Guid>("TwilioSMSID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Body")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("From")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TwilioSMSID");

                    b.ToTable("TwilioSMS");
                });
#pragma warning restore 612, 618
        }
    }
}
