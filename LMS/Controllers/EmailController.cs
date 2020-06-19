using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace LMS.Controllers
{
    public class EmailController : Controller
    {
        // GET: Email
        public ActionResult Form()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Form (string receiver_mail , string subject , string message)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    var senderEmail = new MailAddress("librarymanagementsystem327@gmail.com","LMS");
                    var receiverEmail = new MailAddress(receiver_mail, "Receiver");

                    var password = "LMS@1234";
                    var subj = subject;
                    var body = message;

                    var smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(senderEmail.Address, password)

                    };

                    using (var mess = new MailMessage(senderEmail, receiverEmail)
                    {
                        Subject = subject,
                        Body = body

                    }
                        )
                    {
                        smtp.Send(mess);
                    }
                    return View();

                }
            }
            catch (Exception)
             {
                ViewBag.Error = "There are Some Problem in sending Email";
            }
            return View();
        }
    }
}