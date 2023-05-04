// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Cinemagnesia.Domain.Domain.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Infrastructure.Email.Customs.Interface;

namespace Cinemagnesia.Presentation.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class ResendEmailConfirmationModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ICustomEmailSender _emailSender;

        public ResendEmailConfirmationModel(UserManager<ApplicationUser> userManager, ICustomEmailSender emailSender)
        {
            _userManager = userManager;
            _emailSender = emailSender;
        }

      
        [BindProperty]
        public InputModel Input { get; set; }

       
        public class InputModel
        {
            
            [Required]
            [EmailAddress]
            public string Email { get; set; }
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _userManager.FindByEmailAsync(Input.Email);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Doğrulama e-postası gönderildi. Lütfen e-postanızı kontrol edin.");
                return Page();
            }

            var userId = await _userManager.GetUserIdAsync(user);
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
            var callbackUrl = Url.Page(
                "/Account/ConfirmEmail",
                pageHandler: null,
                values: new { userId = userId, code = code },
                protocol: Request.Scheme);
            await _emailSender.SendConfirmationEmailAsync(Input.Email, callbackUrl);

            ModelState.AddModelError(string.Empty, "Doğrulama e-postası gönderildi. Lütfen e-postanızı kontrol edin.");
            return Page();
        }
    }
}
