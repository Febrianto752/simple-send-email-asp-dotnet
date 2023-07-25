using Microsoft.AspNetCore.Mvc;
using SendEmail.Models;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;

namespace SendEmail.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult SendEmail()
        {
            string fromMail = "hello.world.mcc79@gmail.com";
            string fromPassword = "aixfdspfosmyrcfq";

            MailMessage message = new MailMessage();
            message.From = new MailAddress(fromMail);
            message.Subject = "Test Subject";
            message.To.Add(new MailAddress("optimusprime200039@gmail.com"));
            message.Body = "<html><body> <h1>Hello World</h1> </body></html>";
            message.IsBodyHtml = true;


            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                //UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromMail, fromPassword),
                EnableSsl = true,
            };


            smtpClient.Send(message);

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}