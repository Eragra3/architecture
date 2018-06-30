﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using KekManager.Security.Api.Models.AccountViewModels;
using KekManager.Security.Api.Services;
using KekManager.Security.Domain;
using KekManager.Security.Logic;

namespace KekManager.Security.Api.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class AccountController : Controller
    {
        private readonly ISecurityBl _securityBl;

        public AccountController(ISecurityBl securityBl)
        {
            _securityBl = securityBl;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _securityBl.Login(model.Email, model.Password, model.RememberMe);

            return Ok();
        }
    }
    //    private readonly IEmailSender _emailSender;
    //    private readonly ILogger _logger;

    //    public AccountController(
    //        UserManager<SecurityUser> userManager,
    //        SignInManager<SecurityUser> signInManager,
    //        IEmailSender emailSender,
    //        ILogger<AccountController> logger)
    //    {
    //        this._userManager = userManager;
    //        this._signInManager = signInManager;
    //        this._emailSender = emailSender;
    //        this._logger = logger;
    //    }

    //    [TempData]
    //    public string ErrorMessage { get; set; }

    //    [HttpGet]
    //    [AllowAnonymous]
    //    public async Task<IActionResult> Login(string returnUrl = null)
    //    {
    //        // Clear the existing external cookie to ensure a clean login process
    //        await this.HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

    //        this.ViewData["ReturnUrl"] = returnUrl;
    //        return View();
    //    }

    //    [HttpPost]
    //    [AllowAnonymous]
    //    [ValidateAntiForgeryToken]
    //    public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
    //    {
    //        this.ViewData["ReturnUrl"] = returnUrl;
    //        if (this.ModelState.IsValid)
    //        {
    //            // This doesn't count login failures towards account lockout
    //            // To enable password failures to trigger account lockout, set lockoutOnFailure: true
    //            var result = await this._signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
    //            if (result.Succeeded)
    //            {
    //                this._logger.LogInformation("User logged in.");
    //                return RedirectToLocal(returnUrl);
    //            }
    //            if (result.RequiresTwoFactor)
    //            {
    //                return RedirectToAction(nameof(LoginWith2fa), new { returnUrl, model.RememberMe });
    //            }
    //            if (result.IsLockedOut)
    //            {
    //                this._logger.LogWarning("User account locked out.");
    //                return RedirectToAction(nameof(Lockout));
    //            }
    //            else
    //            {
    //                this.ModelState.AddModelError(string.Empty, "Invalid login attempt.");
    //                return View(model);
    //            }
    //        }

    //        // If we got this far, something failed, redisplay form
    //        return View(model);
    //    }

    //    [HttpGet]
    //    [AllowAnonymous]
    //    public async Task<IActionResult> LoginWith2fa(bool rememberMe, string returnUrl = null)
    //    {
    //        // Ensure the user has gone through the username & password screen first
    //        var user = await this._signInManager.GetTwoFactorAuthenticationUserAsync();

    //        if (user == null)
    //        {
    //            throw new ApplicationException($"Unable to load two-factor authentication user.");
    //        }

    //        var model = new LoginWith2faViewModel { RememberMe = rememberMe };
    //        this.ViewData["ReturnUrl"] = returnUrl;

    //        return View(model);
    //    }

    //    [HttpPost]
    //    [AllowAnonymous]
    //    [ValidateAntiForgeryToken]
    //    public async Task<IActionResult> LoginWith2fa(LoginWith2faViewModel model, bool rememberMe, string returnUrl = null)
    //    {
    //        if (!this.ModelState.IsValid)
    //        {
    //            return View(model);
    //        }

    //        var user = await this._signInManager.GetTwoFactorAuthenticationUserAsync();
    //        if (user == null)
    //        {
    //            throw new ApplicationException($"Unable to load user with ID '{this._userManager.GetUserId(this.User)}'.");
    //        }

    //        var authenticatorCode = model.TwoFactorCode.Replace(" ", string.Empty).Replace("-", string.Empty);

    //        var result = await this._signInManager.TwoFactorAuthenticatorSignInAsync(authenticatorCode, rememberMe, model.RememberMachine);

    //        if (result.Succeeded)
    //        {
    //            this._logger.LogInformation("User with ID {UserId} logged in with 2fa.", user.Id);
    //            return RedirectToLocal(returnUrl);
    //        }
    //        else if (result.IsLockedOut)
    //        {
    //            this._logger.LogWarning("User with ID {UserId} account locked out.", user.Id);
    //            return RedirectToAction(nameof(Lockout));
    //        }
    //        else
    //        {
    //            this._logger.LogWarning("Invalid authenticator code entered for user with ID {UserId}.", user.Id);
    //            this.ModelState.AddModelError(string.Empty, "Invalid authenticator code.");
    //            return View();
    //        }
    //    }

    //    [HttpGet]
    //    [AllowAnonymous]
    //    public async Task<IActionResult> LoginWithRecoveryCode(string returnUrl = null)
    //    {
    //        // Ensure the user has gone through the username & password screen first
    //        var user = await this._signInManager.GetTwoFactorAuthenticationUserAsync();
    //        if (user == null)
    //        {
    //            throw new ApplicationException($"Unable to load two-factor authentication user.");
    //        }

    //        this.ViewData["ReturnUrl"] = returnUrl;

    //        return View();
    //    }

    //    [HttpPost]
    //    [AllowAnonymous]
    //    [ValidateAntiForgeryToken]
    //    public async Task<IActionResult> LoginWithRecoveryCode(LoginWithRecoveryCodeViewModel model, string returnUrl = null)
    //    {
    //        if (!this.ModelState.IsValid)
    //        {
    //            return View(model);
    //        }

    //        var user = await this._signInManager.GetTwoFactorAuthenticationUserAsync();
    //        if (user == null)
    //        {
    //            throw new ApplicationException($"Unable to load two-factor authentication user.");
    //        }

    //        var recoveryCode = model.RecoveryCode.Replace(" ", string.Empty);

    //        var result = await this._signInManager.TwoFactorRecoveryCodeSignInAsync(recoveryCode);

    //        if (result.Succeeded)
    //        {
    //            this._logger.LogInformation("User with ID {UserId} logged in with a recovery code.", user.Id);
    //            return RedirectToLocal(returnUrl);
    //        }
    //        if (result.IsLockedOut)
    //        {
    //            this._logger.LogWarning("User with ID {UserId} account locked out.", user.Id);
    //            return RedirectToAction(nameof(Lockout));
    //        }
    //        else
    //        {
    //            this._logger.LogWarning("Invalid recovery code entered for user with ID {UserId}", user.Id);
    //            this.ModelState.AddModelError(string.Empty, "Invalid recovery code entered.");
    //            return View();
    //        }
    //    }

    //    [HttpGet]
    //    [AllowAnonymous]
    //    public IActionResult Lockout()
    //    {
    //        return View();
    //    }

    //    [HttpGet]
    //    [AllowAnonymous]
    //    public IActionResult Register(string returnUrl = null)
    //    {
    //        this.ViewData["ReturnUrl"] = returnUrl;
    //        return View();
    //    }

    //    [HttpPost]
    //    [AllowAnonymous]
    //    [ValidateAntiForgeryToken]
    //    public async Task<IActionResult> Register(RegisterViewModel model, string returnUrl = null)
    //    {
    //        this.ViewData["ReturnUrl"] = returnUrl;
    //        if (this.ModelState.IsValid)
    //        {
    //            var user = new SecurityUser { UserName = model.Email, Email = model.Email };
    //            var result = await this._userManager.CreateAsync(user, model.Password);
    //            if (result.Succeeded)
    //            {
    //                this._logger.LogInformation("User created a new account with password.");

    //                var code = await this._userManager.GenerateEmailConfirmationTokenAsync(user);
    //                var callbackUrl = this.Url.EmailConfirmationLink(user.Id, code, this.Request.Scheme);
    //                await this._emailSender.SendEmailConfirmationAsync(model.Email, callbackUrl);

    //                await this._signInManager.SignInAsync(user, isPersistent: false);
    //                this._logger.LogInformation("User created a new account with password.");
    //                return RedirectToLocal(returnUrl);
    //            }
    //            AddErrors(result);
    //        }

    //        // If we got this far, something failed, redisplay form
    //        return View(model);
    //    }

    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public async Task<IActionResult> Logout()
    //    {
    //        await this._signInManager.SignOutAsync();
    //        this._logger.LogInformation("User logged out.");
    //        return RedirectToAction(nameof(HomeController.Index), "Home");
    //    }

    //    [HttpPost]
    //    [AllowAnonymous]
    //    [ValidateAntiForgeryToken]
    //    public IActionResult ExternalLogin(string provider, string returnUrl = null)
    //    {
    //        // Request a redirect to the external login provider.
    //        var redirectUrl = this.Url.Action(nameof(ExternalLoginCallback), "Account", new { returnUrl });
    //        var properties = this._signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
    //        return Challenge(properties, provider);
    //    }

    //    [HttpGet]
    //    [AllowAnonymous]
    //    public async Task<IActionResult> ExternalLoginCallback(string returnUrl = null, string remoteError = null)
    //    {
    //        if (remoteError != null)
    //        {
    //            this.ErrorMessage = $"Error from external provider: {remoteError}";
    //            return RedirectToAction(nameof(Login));
    //        }
    //        var info = await this._signInManager.GetExternalLoginInfoAsync();
    //        if (info == null)
    //        {
    //            return RedirectToAction(nameof(Login));
    //        }

    //        // Sign in the user with this external login provider if the user already has a login.
    //        var result = await this._signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false, bypassTwoFactor: true);
    //        if (result.Succeeded)
    //        {
    //            this._logger.LogInformation("User logged in with {Name} provider.", info.LoginProvider);
    //            return RedirectToLocal(returnUrl);
    //        }
    //        if (result.IsLockedOut)
    //        {
    //            return RedirectToAction(nameof(Lockout));
    //        }
    //        else
    //        {
    //            // If the user does not have an account, then ask the user to create an account.
    //            this.ViewData["ReturnUrl"] = returnUrl;
    //            this.ViewData["LoginProvider"] = info.LoginProvider;
    //            var email = info.Principal.FindFirstValue(ClaimTypes.Email);
    //            return View("ExternalLogin", new ExternalLoginViewModel { Email = email });
    //        }
    //    }

    //    [HttpPost]
    //    [AllowAnonymous]
    //    [ValidateAntiForgeryToken]
    //    public async Task<IActionResult> ExternalLoginConfirmation(ExternalLoginViewModel model, string returnUrl = null)
    //    {
    //        if (this.ModelState.IsValid)
    //        {
    //            // Get the information about the user from the external login provider
    //            var info = await this._signInManager.GetExternalLoginInfoAsync();
    //            if (info == null)
    //            {
    //                throw new ApplicationException("Error loading external login information during confirmation.");
    //            }
    //            var user = new SecurityUser { UserName = model.Email, Email = model.Email };
    //            var result = await this._userManager.CreateAsync(user);
    //            if (result.Succeeded)
    //            {
    //                result = await this._userManager.AddLoginAsync(user, info);
    //                if (result.Succeeded)
    //                {
    //                    await this._signInManager.SignInAsync(user, isPersistent: false);
    //                    this._logger.LogInformation("User created an account using {Name} provider.", info.LoginProvider);
    //                    return RedirectToLocal(returnUrl);
    //                }
    //            }
    //            AddErrors(result);
    //        }

    //        this.ViewData["ReturnUrl"] = returnUrl;
    //        return View(nameof(ExternalLogin), model);
    //    }

    //    [HttpGet]
    //    [AllowAnonymous]
    //    public async Task<IActionResult> ConfirmEmail(string userId, string code)
    //    {
    //        if (userId == null || code == null)
    //        {
    //            return RedirectToAction(nameof(HomeController.Index), "Home");
    //        }
    //        var user = await this._userManager.FindByIdAsync(userId);
    //        if (user == null)
    //        {
    //            throw new ApplicationException($"Unable to load user with ID '{userId}'.");
    //        }
    //        var result = await this._userManager.ConfirmEmailAsync(user, code);
    //        return View(result.Succeeded ? "ConfirmEmail" : "Error");
    //    }

    //    [HttpGet]
    //    [AllowAnonymous]
    //    public IActionResult ForgotPassword()
    //    {
    //        return View();
    //    }

    //    [HttpPost]
    //    [AllowAnonymous]
    //    [ValidateAntiForgeryToken]
    //    public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
    //    {
    //        if (this.ModelState.IsValid)
    //        {
    //            var user = await this._userManager.FindByEmailAsync(model.Email);
    //            if (user == null || !(await this._userManager.IsEmailConfirmedAsync(user)))
    //            {
    //                // Don't reveal that the user does not exist or is not confirmed
    //                return RedirectToAction(nameof(ForgotPasswordConfirmation));
    //            }

    //            // For more information on how to enable account confirmation and password reset please
    //            // visit https://go.microsoft.com/fwlink/?LinkID=532713
    //            var code = await this._userManager.GeneratePasswordResetTokenAsync(user);
    //            var callbackUrl = this.Url.ResetPasswordCallbackLink(user.Id, code, this.Request.Scheme);
    //            await this._emailSender.SendEmailAsync(model.Email, "Reset Password",
    //               $"Please reset your password by clicking here: <a href='{callbackUrl}'>link</a>");
    //            return RedirectToAction(nameof(ForgotPasswordConfirmation));
    //        }

    //        // If we got this far, something failed, redisplay form
    //        return View(model);
    //    }

    //    [HttpGet]
    //    [AllowAnonymous]
    //    public IActionResult ForgotPasswordConfirmation()
    //    {
    //        return View();
    //    }

    //    [HttpGet]
    //    [AllowAnonymous]
    //    public IActionResult ResetPassword(string code = null)
    //    {
    //        if (code == null)
    //        {
    //            throw new ApplicationException("A code must be supplied for password reset.");
    //        }
    //        var model = new ResetPasswordViewModel { Code = code };
    //        return View(model);
    //    }

    //    [HttpPost]
    //    [AllowAnonymous]
    //    [ValidateAntiForgeryToken]
    //    public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
    //    {
    //        if (!this.ModelState.IsValid)
    //        {
    //            return View(model);
    //        }
    //        var user = await this._userManager.FindByEmailAsync(model.Email);
    //        if (user == null)
    //        {
    //            // Don't reveal that the user does not exist
    //            return RedirectToAction(nameof(ResetPasswordConfirmation));
    //        }
    //        var result = await this._userManager.ResetPasswordAsync(user, model.Code, model.Password);
    //        if (result.Succeeded)
    //        {
    //            return RedirectToAction(nameof(ResetPasswordConfirmation));
    //        }
    //        AddErrors(result);
    //        return View();
    //    }

    //    [HttpGet]
    //    [AllowAnonymous]
    //    public IActionResult ResetPasswordConfirmation()
    //    {
    //        return View();
    //    }


    //    [HttpGet]
    //    public IActionResult AccessDenied()
    //    {
    //        return View();
    //    }

    //    #region Helpers

    //    private void AddErrors(IdentityResult result)
    //    {
    //        foreach (var error in result.Errors)
    //        {
    //            this.ModelState.AddModelError(string.Empty, error.Description);
    //        }
    //    }

    //    private IActionResult RedirectToLocal(string returnUrl)
    //    {
    //        if (this.Url.IsLocalUrl(returnUrl))
    //        {
    //            return Redirect(returnUrl);
    //        }
    //        else
    //        {
    //            return RedirectToAction(nameof(HomeController.Index), "Home");
    //        }
    //    }

    //    #endregion
    //  }
}
