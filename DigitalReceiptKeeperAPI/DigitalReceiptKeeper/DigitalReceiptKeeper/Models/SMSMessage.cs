using System.ComponentModel.DataAnnotations;

namespace DigitalReceiptKeeper.Models
{
    public class SMSMessage
    {
        [Key]
        public Guid MessageID { get; set; }
        public string TwilioMessageID { get; set; }
        public string Sender { get; set; }
        public string MessageContent { get; set; }
        public DateTime DateReceived { get; set; }
        public bool ContainReceipt { get; set; }

   
    }
}
