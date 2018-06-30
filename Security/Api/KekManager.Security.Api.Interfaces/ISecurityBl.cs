﻿using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace KekManager.Security.Logic
{
    public interface ISecurityBl
    {
        Task<SignInResult> Login(string userName, string password, bool rememberMe = false);
    }
}