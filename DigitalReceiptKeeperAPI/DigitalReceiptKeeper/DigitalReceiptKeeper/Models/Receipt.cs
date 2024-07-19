using System.ComponentModel.DataAnnotations.Schema;
using Twilio.AspNet.Common;

namespace DigitalReceiptKeeper.Models
{
    public class Receipt
    {
        public Guid ReceiptID { get; set; }
        public string StoreName { get; set; }
        public string ReceiptDate { get; set; }
        public string ReceiptFilePath { get; set; }
        public string ReceiptCategory { get; set;}
        public string ReceiptNote { get; set; }
        public string ReceiptAmount { get; set; }

    }
}
