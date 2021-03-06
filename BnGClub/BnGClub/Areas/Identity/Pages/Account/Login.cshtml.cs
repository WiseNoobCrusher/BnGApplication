﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using BnGClub.Data;
using BnGClub.Utilities;

namespace BnGClub.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<LoginModel> _logger;
        private readonly BnGClubContext _context;

        public LoginModel(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, ILogger<LoginModel> logger, BnGClubContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _context = context;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Display(Name = "Remember me?")]
            public bool RememberMe { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }

            returnUrl = returnUrl ?? Url.Content("~/");

            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);
            //David Stovell-Clear userName cookie
            HttpContext.Response.Cookies.Delete("userName");

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");

            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await _signInManager.PasswordSignInAsync(Input.Email, Input.Password, Input.RememberMe, lockoutOnFailure: true);
                if (result.Succeeded)
                {
                    var users = _userManager.Users.Where(r => r.Email == Input.Email).FirstOrDefault();
                    var roles = _signInManager.UserManager.GetRolesAsync(users).Result;

                    var role = "";
                    foreach (var r in roles)
                    {
                        role = r;
                        break;
                    }

                    if (role == "Parent")
                    {
                        var user = _context.Users.Where(u => u.userEmail == Input.Email).FirstOrDefault();
                        if (user != null)
                        {
                            CookieHelper.CookieSet(HttpContext, "userName", user.FullName, 3200);
                        }
                        else
                        {
                            //What better time to create the profile?
                            returnUrl = "~/UsersProfile/Create";
                        }
                    }
                    else if (role == "Instructor")
                    {
                        var leader = _context.Leaders.Where(l => l.leaderEmail == Input.Email).FirstOrDefault();
                        if (leader != null)
                        {
                            CookieHelper.CookieSet(HttpContext, "userName", leader.FullName, 3200);
                        }
                        else
                        {
                            //What better time to create the profile?
                            returnUrl = "~/LeadersProfile/Create";
                        }
                    }
                    _logger.LogInformation("User logged in.");
                    return LocalRedirect(returnUrl);
                }
                if (result.RequiresTwoFactor)
                {
                    return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, RememberMe = Input.RememberMe });
                }
                if (result.IsLockedOut)
                {
                    _logger.LogWarning("User account locked out.");
                    return RedirectToPage("./Lockout");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return Page();
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
