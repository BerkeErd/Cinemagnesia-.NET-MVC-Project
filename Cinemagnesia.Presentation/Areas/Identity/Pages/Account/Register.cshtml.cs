// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Cinemagnesia.Domain.Domain.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using System.Runtime.CompilerServices;
using Infrastructure.Email.Customs.Interface;

namespace Cinemagnesia.Presentation.Areas.Identity.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserStore<ApplicationUser> _userStore;
        private readonly IUserEmailStore<ApplicationUser> _emailStore;
        private readonly ILogger<RegisterModel> _logger;
        private readonly ICustomEmailSender _emailSender;

        public RegisterModel(
            UserManager<ApplicationUser> userManager,
            IUserStore<ApplicationUser> userStore,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger,
            ICustomEmailSender emailSender)
        {
            _userManager = userManager;
            _userStore = userStore;
            _emailStore = GetEmailStore();
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
        }

        
        [BindProperty]
        public InputModel Input { get; set; }

      
        public string ReturnUrl { get; set; }

     
        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required]
            [StringLength(25, ErrorMessage = "{0} en az {2}, en fazla {1} karakter uzunluğunda olmalıdır.", MinimumLength = 3)]
            [Display(Name = "İsim")]
            public string FirstName { get; set; }

            [Required]
            [StringLength(25, ErrorMessage = "{0} en az {2}, en fazla {1} karakter uzunluğunda olmalıdır.", MinimumLength = 2)]
            [Display(Name = "Soy İsim")]
            public string LastName { get; set; }

            [Required]
            [Display(Name = "Doğum Günü")]
            public DateTime Birthday { get; set; }

            [Required]
            [EmailAddress]
            [Display(Name = "E-posta")]
            public string Email { get; set; }

            [StringLength(100, ErrorMessage = "{0} en az {2}, en fazla {1} karakter uzunluğunda olmalıdır.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Parola")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Parolayı Onayla")]
            [Compare("Password", ErrorMessage = "Parola ve parola onayı eşleşmiyor.")]
            public string ConfirmPassword { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var user = CreateUser();

                await _userStore.SetUserNameAsync(user, Input.Email, CancellationToken.None);
                await _emailStore.SetEmailAsync(user, Input.Email, CancellationToken.None);
                var result = await _userManager.CreateAsync(user, Input.Password);

                if (result.Succeeded)
                {
                    _logger.LogInformation("Kullanıcı yeni bir hesap oluşturdu.");

                    var userId = await _userManager.GetUserIdAsync(user);
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = userId, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    await _emailSender.SendConfirmationEmailAsync(Input.Email, callbackUrl);

                    await _userManager.AddToRoleAsync(user, "User");
                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // Eğer buraya kadar geldiysek, bir şeyler yanlış gitti, formu tekrar göster
            return Page();
        }

        private ApplicationUser CreateUser()
        {
            try
            {
                var user = new ApplicationUser
                {
                    FirstName = Input.FirstName,
                    LastName = Input.LastName,
                    UserName = Input.Email,
                    ProfilePicture = "defaultUserPicture.png",
                    AccountCreationDate = DateTime.Now,
                    Birthday = Input.Birthday,
                    Email = Input.Email
                };
                return user;
            }
            catch
            {
                throw new InvalidOperationException($"'{nameof(ApplicationUser)}' örneği oluşturulamadı. " +
                $"'{nameof(ApplicationUser)}' soyut bir sınıf değilse ve parametresiz bir yapıcı metodu varsa veya alternatif olarak " +
                $"/Areas/Identity/Pages/Account/Register.cshtml sayfasını geçersiz kılmışsanız kontrol edin.");
            }
        }

    private IUserEmailStore<ApplicationUser> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("Varsayılan kullanıcı arayüzü, e-posta desteği olan bir kullanıcı deposuna ihtiyaç duyar.");
            }
            return (IUserEmailStore<ApplicationUser>)_userStore;
        }
    }
}
