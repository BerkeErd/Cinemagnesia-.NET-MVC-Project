using Cinemagnesia.Domain.Domain.Entities.Concrete;
using Infrastructure.Email.Customs.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Cinemagnesia.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SendEmailController : Controller
    {
        private readonly ICustomEmailSender _customEmailSender;
        private readonly UserManager<ApplicationUser> _usermanager;

        public SendEmailController(ICustomEmailSender customEmailSender, UserManager<ApplicationUser> usermanager)
        {
            _customEmailSender = customEmailSender;
            _usermanager = usermanager;
        }

        public IActionResult Index()
        {
            ViewBag.Message = TempData["Message"];
            ViewBag.Code = TempData["Code"];
            ViewBag.Users = _usermanager.Users;
            return View();
        }


        [HttpPost]
        public IActionResult SendCustomEmail(string userEmail, string emailSubject, string emailText)
        {
            try
            {
                if (!string.IsNullOrEmpty(userEmail) && !string.IsNullOrEmpty(emailSubject) && !string.IsNullOrEmpty(emailText))
                {
                    if (userEmail == "all")
                    {
                        foreach (var user in _usermanager.Users)
                        {
                            try
                            {
                                if (user.Email != null)
                                {
                                    _customEmailSender.SendCustomEmailAsync(user.Email, emailSubject, emailText).Wait();
                                }
                            }
                            catch (Exception e)
                            {
                                TempData["Message"] = e.Message;
                                TempData["Code"] = "400";
                                return RedirectToAction("SendEmail", "Admin");
                            }
                        }
                        TempData["Message"] = "Mesaj tüm kullanıcılara gönderildi.";
                        TempData["Code"] = "200";
                        return RedirectToAction("SendEmail", "Admin");
                    }
                    else
                    {
                        
                        _customEmailSender.SendCustomEmailAsync(userEmail, emailSubject, emailText).Wait();
                        TempData["Message"] = "Mesaj " + userEmail + " eposta adresine gönderildi.";
                        TempData["Code"] = "200";
                        return RedirectToAction("SendEmail", "Admin");
                    }
                }
                TempData["Message"] = "Lütfen bütün inputları doldurunuz.";
                TempData["Code"] = "400";
                return RedirectToAction("SendEmail", "Admin");
            }
            catch (Exception e)
            {
                TempData["Message"] = e.Message;
                TempData["Code"] = "400";
                return RedirectToAction("SendEmail", "Admin");
            }
        }

    }
}
