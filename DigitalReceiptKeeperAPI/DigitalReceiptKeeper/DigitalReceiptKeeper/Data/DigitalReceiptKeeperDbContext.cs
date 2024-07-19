using DigitalReceiptKeeper.Models;
using Microsoft.EntityFrameworkCore;

namespace DigitalReceiptKeeper.Data
{
    public class DigitalReceiptKeeperDbContext : DbContext
    {
        public DigitalReceiptKeeperDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<TwilioSMS> TwilioSMS { get; set; }
        public DbSet<QRCode> QRCodes { get; set; }
        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<SMSMessage> SMSMessages { get; set; }

    }
}
