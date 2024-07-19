namespace DigitalReceiptKeeper.Models
{
    public class TwilioSMS
    {
        
        public Guid TwilioSMSID { get; set; }
        public string From { get; set; }
        public string Body { get; set; }
    }
}
