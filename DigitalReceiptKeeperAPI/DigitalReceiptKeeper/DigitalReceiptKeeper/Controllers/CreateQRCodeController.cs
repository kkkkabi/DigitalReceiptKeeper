using DigitalReceiptKeeper.Data;
using DigitalReceiptKeeper.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DigitalReceiptKeeper.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CreateQRCodeController : Controller
    {
        private readonly DigitalReceiptKeeperDbContext _digitalreceiptkeeperDbcontext;
        public CreateQRCodeController(DigitalReceiptKeeperDbContext digitalReceiptKeeperDbContext)
        {
            _digitalreceiptkeeperDbcontext = digitalReceiptKeeperDbContext;
        }

        public DigitalReceiptKeeperDbContext DigitalReceiptKeeperDbContext { get; }

        [HttpGet]
        public async Task <IActionResult> GetQRcode()
        {
            var qrcode = await _digitalreceiptkeeperDbcontext.QRCodes.ToListAsync();

            return Ok(qrcode);
        }

        [HttpPost]
        public async Task<IActionResult> AddQRcode([FromBody] QRCode qrcoderRequest)
        {
            qrcoderRequest.QRCodeID = Guid.NewGuid();
            await _digitalreceiptkeeperDbcontext.QRCodes.AddAsync(qrcoderRequest);
            await _digitalreceiptkeeperDbcontext.SaveChangesAsync();

            return Ok(qrcoderRequest);
        }
    }
}

