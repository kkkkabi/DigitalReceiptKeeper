using DigitalReceiptKeeper.Data;
using DigitalReceiptKeeper.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DigitalReceiptKeeper.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QRcodeController : Controller
    {
        private readonly DigitalReceiptKeeperDbContext _digitalReceiptKeeperDbContext;

        public QRcodeController(DigitalReceiptKeeperDbContext digitalReceiptKeeperDbContext)
        {
            _digitalReceiptKeeperDbContext = digitalReceiptKeeperDbContext;
        }

        // Display qrcode list
        [HttpGet("viewall")]
        public async Task<IActionResult> GetAllQrcodes()
        {
            var qrcodes = await _digitalReceiptKeeperDbContext.QRCodes.ToListAsync();

            return Ok(qrcodes);
        }

        // Add new QR code
        [HttpPost("create")]
        public async Task<IActionResult> AddQRcode([FromBody] QRCode addqrcode)
        {
            await _digitalReceiptKeeperDbContext.QRCodes.AddAsync(addqrcode);
            await _digitalReceiptKeeperDbContext.SaveChangesAsync();

            return Ok(addqrcode);
        }


        // Display one qrcode with QR code ID
        [HttpGet]
        [Route("fetch/{qrcodeid:Guid}")]

        public async Task<IActionResult> ShowQRcode([FromRoute] Guid qrcodeid)
        {
            var qrcode =
                await _digitalReceiptKeeperDbContext.QRCodes.FirstOrDefaultAsync(x => x.QRCodeID == qrcodeid);

            if (qrcode == null)
            {
                return NotFound();
            }

            return Ok(qrcode);

        }

        // Update QRcode details
        [HttpPut]
        [Route("{qrcodeid:Guid}")]
        
        public async Task<IActionResult> UpdateQRcode([FromRoute] Guid qrcodeid, QRCode updateQRcodeRequest)
        {
            var qrcode = await _digitalReceiptKeeperDbContext.QRCodes.FindAsync(qrcodeid);
            if (qrcode == null)
            {
                return NotFound();
            }

            qrcode.QRCodeName = updateQRcodeRequest.QRCodeName;
            qrcode.QRCodeContent = updateQRcodeRequest.QRCodeContent;
            qrcode.QRCodeImagePath = updateQRcodeRequest.QRCodeImagePath;
            qrcode.QRCodeCategory = updateQRcodeRequest.QRCodeCategory;

            await _digitalReceiptKeeperDbContext.SaveChangesAsync();
            return Ok(qrcode);
        }

        // Delete QR code
        [HttpDelete]
        [Route("{qrcodeid:Guid}")]
        public async Task<IActionResult> DeleteQrcode([FromRoute] Guid qrcodeid)
        {
            var qrcode = await _digitalReceiptKeeperDbContext.QRCodes.FindAsync(qrcodeid);

            if(qrcode == null)
            {
                return NotFound();
            }

            _digitalReceiptKeeperDbContext.QRCodes.Remove(qrcode);
            await _digitalReceiptKeeperDbContext.SaveChangesAsync();
            return Ok(qrcode);

        }

        // Get lastest QRcode
        [HttpGet("latest")]
        public async Task<IActionResult> GetLatestQRcode()
        {
            var latestQRcode = await _digitalReceiptKeeperDbContext.QRCodes
                .OrderByDescending(q => q.QRCodeCreatedTime)
                .FirstOrDefaultAsync();
            if(latestQRcode == null)
                return NotFound();
            return Ok(latestQRcode);
        }

    }       
}