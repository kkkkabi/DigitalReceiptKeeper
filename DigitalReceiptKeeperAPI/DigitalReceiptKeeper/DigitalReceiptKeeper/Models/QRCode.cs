namespace DigitalReceiptKeeper.Models
{
    public class QRCode
    {
        public Guid QRCodeID { get; set; }
        public string QRCodeName { get; set; }
        public string QRCodeContent { get; set; }
        public string QRCodeCategory { get; set; }
        public string QRCodeImagePath { get; set; }
        public DateTime QRCodeCreatedTime { get; set; }
    }
}
