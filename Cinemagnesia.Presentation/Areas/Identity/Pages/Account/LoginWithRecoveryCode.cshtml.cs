// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Cinemagnesia.Domain.Domain.Entities.Concrete;

namespace Cinemagnesia.Presentation.Areas.Identity.Pages.Account
{
    public class LoginWithRecoveryCodeModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<LoginWithRecoveryCodeModel> _logger;

        public LoginWithRecoveryCodeModel(
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager,
            ILogger<LoginWithRecoveryCodeModel> logger)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _logger = logger;
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string ReturnUrl { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public class InputModel
        {
            /// <summary>
            /// Bu API, ASP.NET Core Identity varsayılan UI altyapısı tarafından desteklenmektedir ve doğrudan kodunuzdan
            /// kullanmak için tasarlanmamıştır. Bu API gelecekteki sürümlerde değiştirilebilir veya kaldırılabilir.
            /// </summary>
            [BindProperty]
            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Kurtarma Kodu")]
            public string RecoveryCode { get; set; }
        }

        public async Task<IActionResult> OnGetAsync(string returnUrl = null)
        {
            // Kullanıcının önce kullanıcı adı ve şifre ekranından geçtiğinden emin olun
            var user = await _signInManager.GetTwoFactorAuthenticationUserAsync();
            if (user == null)
            {
                throw new InvalidOperationException($"İki faktörlü kimlik doğrulama kullanıcısı yüklenemedi.");
            }

            ReturnUrl = returnUrl;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _signInManager.GetTwoFactorAuthenticationUserAsync();
            if (user == null)
            {
                throw new InvalidOperationException($"İki faktörlü kimlik doğrulama kullanıcısı yüklenemedi.");
            }

            var recoveryCode = Input.RecoveryCode.Replace(" ", string.Empty);

            var result = await _signInManager.TwoFactorRecoveryCodeSignInAsync(recoveryCode);

            var userId = await _userManager.GetUserIdAsync(user);

            if (result.Succeeded)
            {
                _logger.LogInformation("ID'si '{UserId}' olan kullanıcı kurtarma koduyla giriş yaptı.", user.Id);
                return LocalRedirect(returnUrl ?? Url.Content("~/"));
            }
            if (result.IsLockedOut)
            {
                _logger.LogWarning("Kullanıcı hesabı kilitlendi.");
                return RedirectToPage("./Lockout");
            }
            else
            {
                _logger.LogWarning("Geçersiz kurtarma kodu, ID'si '{UserId}' olan kullanıcı için girildi.", user.Id);
                ModelState.AddModelError(string.Empty, "Geçersiz kurtarma kodu girildi.");
                return Page();
            }
        }
    }
}
