using DigitalReceiptKeeper.Models;
using Microsoft.AspNetCore.Mvc;
using Twilio.AspNet.Core;
using Twilio.TwiML;

/*this controller is for capturing the responses to our trilio phone number*/
namespace DigitalReceiptKeeper.Controllers
{

    [ApiController]
    [Route("api/[controller]")]

    public class ReceiveSMSController : TwilioController
    {
        [HttpPost("SendReply")]
        public TwiMLResult SendReply([FromForm] TwilioSMS request)
        {

/*--------------------- automatic response end---------------------*/
            var response = new MessagingResponse(); /* MessagingResponse() send automatic response to who text us*/
            response.Message("I receive the text!");
/*--------------------- automatic response end---------------------*/

            return TwiML(response);
        }
    }
}
