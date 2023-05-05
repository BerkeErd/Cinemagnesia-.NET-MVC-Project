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
                                return BadRequest(e.Message);
                            }
                        }
                        return Ok("Mesaj tüm kullanıcılara gönderildi.");
                    }
                    else
                    {
                        
                            _customEmailSender.SendCustomEmailAsync(userEmail, emailSubject, emailText).Wait();
                            return Ok("Mesaj başarıyla" + userEmail + " eposta adresine gönderildi.");
                        
                    }
                }

                return BadRequest("Lütfen bütün inputları doldurunuz.");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
