using Park_Play.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using Twilio.TwiML;
using Twilio.AspNet.Mvc;


namespace Park_Play.Controllers
{
    public class SMSController : TwilioController
    {
        ApplicationDbContext context;

        public SMSController()
        {
            context = new ApplicationDbContext();
        }
        public ActionResult SendSMS(User user)
        {


            var accountSid = APIKeys.TwilioaccountSid;
            var authToken = APIKeys.TwilioauthToken;
            TwilioClient.Init(accountSid, authToken);

            var to = new PhoneNumber("+1" + user.phoneNumber);
            var from = new PhoneNumber("+12027409393");

            var message = MessageResource.Create(
                to: to,
                from: from,
                body: "Check out your recommended Play Events!");
            return Content(message.Sid);

            return View();
        }
    }
}
