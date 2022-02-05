using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;


namespace Finance_D_argent.Controllers
{
    public class SendMailerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        //[HttpPost]
        //public ViewResult Index(Finance_D_argent.Models.MailModel _objModelMail)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        MailMessage mail = new MailMessage();
        //        mail.To.Add(_objModelMail.To);
        //        mail.From = new MailAddress(_objModelMail.From);
        //        mail.Subject = _objModelMail.Subject;
        //        string Body = _objModelMail.Body;
        //        mail.Body = Body;
        //        mail.IsBodyHtml = true;
        //        SmtpClient smtp = new SmtpClient();
        //        smtp.Host = "smtp.gmail.com";
        //        smtp.Port = 587;
        //        smtp.UseDefaultCredentials = false;
        //        smtp.Credentials = new System.Net.NetworkCredential("adjegba3414@gmail.com", "Ruthrose23"); // Enter seders User name and password  
        //        smtp.EnableSsl = true;
        //        smtp.Send(mail);
        //        return View("Index", _objModelMail);
        //    }
        //    else
        //    {
        //        return View();
        //    }
        //}
    }
}
