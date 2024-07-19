using Microsoft.AspNetCore.Mvc;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace DigitalReceiptKeeper.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SendSMSController : ControllerBase     /*Change to ControllerBase becasue we don't have view*/
    {
        string accountSid = "ACed1666880f2a339f9bca41440fb828a3";
        string authToken = "d3ca22a34a634d6936e56f2ff951dc21";

        [HttpPost("SendText")]
        public ActionResult SendText(string phoneNnumber) /*PhoneNumber is the person we are going to be texting*/
        {
            TwilioClient.Init(accountSid, authToken);
            var message = MessageResource.Create(
                body: "testing for digital receipt keeper",
                from: new Twilio.Types.PhoneNumber("+61483904611"), /*our number*/
                to: new Twilio.Types.PhoneNumber("+61" + phoneNnumber)    /*receiver*/
                );

            return StatusCode(200, new { message = message.Sid }); /*the ID of the message we sent out*/
        }
    }
}
