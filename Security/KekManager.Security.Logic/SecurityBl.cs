﻿using KekManager.Security.Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace KekManager.Security.Logic
{
    public class SecurityBl : ISecurityBl
    {
        private readonly UserManager<SecurityUser> _userManager;
        private readonly SignInManager<SecurityUser> _signInManager;

        public SecurityBl(UserManager<SecurityUser> userManager, SignInManager<SecurityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<SignInResult> Login(string userName, string password, bool rememberMe = false)
        {
            //This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, set lockoutOnFailure: true
            return await _signInManager.PasswordSignInAsync(userName, password, rememberMe, lockoutOnFailure: false);
        }
    }
}