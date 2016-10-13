using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;
using System.Threading.Tasks;
using NLog;
using ServiceStation.Models;

namespace ServiceStation.Controllers
{
    //[Authorize]
    public class SettingsController : Controller
    {
        private static NLog.Logger logger = LogManager.GetCurrentClassLogger();

        public ActionResult Index()
        {
            
            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Contact with Us";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Contact(ContactViewModel contact)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    MailMessage msz = new MailMessage();
                    msz.From = new MailAddress(contact.Email);
                    msz.To.Add("justadreampictures@gmail.com");
                    msz.Body = String.Format("Name: " + contact.Name + "\n\nE-mail: " + contact.Email + "\n\nMessage: " + contact.Message);
                    msz.Subject = "site - DogCoding";

                    SmtpClient smpt = new SmtpClient();
                    smpt.Host = "smtp.gmail.com";
                    smpt.Port = 587;
                    smpt.Credentials = new System.Net.NetworkCredential("justadreampictures", "q26s4hcxz23");

                    smpt.EnableSsl = true;
                    await smpt.SendMailAsync(msz);

                    ModelState.Clear();
                    ViewBag.Message = "Thank you for Contacting me.";
                }
                catch (Exception ex)
                {
                    ViewBag.MessageError = "Sorry, but a problem occured on the server, please try again after some time.";
                    ModelState.Clear();
                    logger.Error("Faild in ContactsController async Task<ActionResult> Index [HttpPost]: ", ex.Source, ex.InnerException, ex.StackTrace, ex.HelpLink, ex.TargetSite, ex.HResult);
                }
            }
            else { ViewBag.MessageError = "You have entered invalid data."; }

            return View();
        }
    }
}
