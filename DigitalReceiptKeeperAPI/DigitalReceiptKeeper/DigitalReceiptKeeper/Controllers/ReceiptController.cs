using DigitalReceiptKeeper.Data;
using DigitalReceiptKeeper.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DigitalReceiptKeeper.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReceiptController : Controller
    {
        private readonly DigitalReceiptKeeperDbContext _digitalReceiptKeeperDbContext;

        public ReceiptController(DigitalReceiptKeeperDbContext digitalReceiptKeeperDbContext)
        {
            _digitalReceiptKeeperDbContext = digitalReceiptKeeperDbContext;
        }

        // Display all receipts
        [HttpGet("viewall")]
        public async Task<IActionResult> GetAllReceipts()
        {
            var receipts = await _digitalReceiptKeeperDbContext.Receipts
                .OrderByDescending( r => r.ReceiptDate)
                .ToListAsync();

            return Ok(receipts);

        }


        // Add new receipt
        [HttpPost("create")]
        public async Task<IActionResult> AddReceipt([FromBody] Receipt addreceipt)
        {
            await _digitalReceiptKeeperDbContext.Receipts.AddAsync(addreceipt);
            await _digitalReceiptKeeperDbContext.SaveChangesAsync();

            return Ok(addreceipt);
        }

        // Display one Receipt with receipt ID
        [HttpGet]
        [Route("fetch/{receiptid:Guid}")]

        public async Task<IActionResult> ShowReceipt([FromRoute] Guid receiptid)
        {
            var receipt =
                await _digitalReceiptKeeperDbContext.Receipts.FirstOrDefaultAsync(x => x.ReceiptID == receiptid);

            if (receipt == null)
            {
                return NotFound();
            }

            return Ok(receipt);

        }

        // Update Receipt details
        [HttpPut]
        [Route("{receiptid:Guid}")]

        public async Task<IActionResult> UpdateReceipt([FromRoute] Guid receiptid, Receipt updateReceiptRequest)
        {
            var receipt = await _digitalReceiptKeeperDbContext.Receipts.FindAsync(receiptid);
            if (receipt == null)
            {
                return NotFound();
            }

            receipt.ReceiptID = updateReceiptRequest.ReceiptID;
            receipt.StoreName = updateReceiptRequest.StoreName;
            receipt.ReceiptDate = updateReceiptRequest.ReceiptDate;
            receipt.ReceiptFilePath = updateReceiptRequest.ReceiptFilePath;
            receipt.ReceiptCategory = updateReceiptRequest.ReceiptCategory;
            receipt.ReceiptNote =  updateReceiptRequest.ReceiptNote;
            receipt.ReceiptAmount =  updateReceiptRequest.ReceiptAmount;

            await _digitalReceiptKeeperDbContext.SaveChangesAsync();
            return Ok(receipt);
        }


        // Delete Receipt
        [HttpDelete]
        [Route("{receiptid:Guid}")]
        public async Task<IActionResult> DeleteReceipt([FromRoute] Guid receiptid)
        {
            var receipt = await _digitalReceiptKeeperDbContext.Receipts.FindAsync(receiptid);

            if (receipt == null)
            {
                return NotFound();
            }

            _digitalReceiptKeeperDbContext.Receipts.Remove(receipt);
            await _digitalReceiptKeeperDbContext.SaveChangesAsync();
            return Ok(receiptid);

        }
    }
}
