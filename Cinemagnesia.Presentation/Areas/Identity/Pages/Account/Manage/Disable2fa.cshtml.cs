// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.Threading.Tasks;
using Cinemagnesia.Domain.Domain.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Cinemagnesia.Presentation.Areas.Identity.Pages.Account.Manage
{
    public class Disable2faModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<Disable2faModel> _logger;

        public Disable2faModel(
            UserManager<ApplicationUser> userManager,
            ILogger<Disable2faModel> logger)
        {
            _userManager = userManager;
            _logger = logger;
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [TempData]
        public string StatusMessage { get; set; }

        public async Task<IActionResult> OnGet()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"ID'si '{_userManager.GetUserId(User)}' olan kullanıcı yüklenemedi.");
            }

            
            if (!await _userManager.GetTwoFactorEnabledAsync(user))
            {
                throw new InvalidOperationException($"Kullanıcının 2FA'sı şu anda etkin değil, devre dışı bırakılamaz.");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"ID'si '{_userManager.GetUserId(User)}' olan kullanıcı yüklenemedi.");
            }

            var disable2faResult = await _userManager.SetTwoFactorEnabledAsync(user, false);
            if (!disable2faResult.Succeeded)
            {
                throw new InvalidOperationException($"2FA devre dışı bırakılırken beklenmeyen bir hata oluştu.");
            }

            _logger.LogInformation("ID'si '{UserId}' olan kullanıcı 2FA'yı devre dışı bıraktı.", _userManager.GetUserId(User));
            StatusMessage = "2fa devre dışı bırakıldı. Doğrulama uygulaması kurduğunuzda 2fa'yı tekrar etkinleştirebilirsiniz.";
            return RedirectToPage("./TwoFactorAuthentication");
        }
    }
}
