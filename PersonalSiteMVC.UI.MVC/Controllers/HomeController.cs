using PersonalSiteMVC.UI.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace PersonalSiteMVC.UI.MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [HttpPost]
        public JsonResult ContactAjax(ContactViewModel cvm)
        {
            string body = $"{cvm.Name} has sent you the following message: <br />" + $"{cvm.Message} <strong>from the email address:</strong> {cvm.Email}";
            MailMessage m = new MailMessage("admin@jamesearp.com", "Jamesaearp@outlook.com", cvm.Subject, body);
            m.IsBodyHtml = true;
            m.Priority = MailPriority.High;
            m.ReplyToList.Add(cvm.Email);
            SmtpClient client = new SmtpClient("mail.jamesearp.com");
            client.Credentials = new NetworkCredential("admin@jamesearp.com", "Incorrect1999#");
            client.Port = 8889;
            try
            { 
                client.Send(m);
            }
            catch (Exception e)
            {

                ViewBag.Message = e.StackTrace;
            }
            return Json(cvm);
        }
        public ActionResult Resume()
        {
            return View();
        }
    }
}