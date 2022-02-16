using Microsoft.AspNetCore.Identity;
using Project.Entities;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Managers
{
    
    public class AuthentificationManager : IAuthentificationManager
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly ITokenManager tokenManager;
        public AuthentificationManager(UserManager<User> userManager, SignInManager<User> signInManager,ITokenManager tokenManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.tokenManager = tokenManager;
        }
        public async Task<TokensModel> Login(LoginModel loginModel)
        {
            var user = await userManager.FindByEmailAsync(loginModel.Email);
            if (user != null)
            {
                var result = await signInManager.CheckPasswordSignInAsync(user, loginModel.Password, false);
                if (result.Succeeded)
                {
                    var token = await tokenManager.GenerateToken(user);

                    return new TokensModel
                    {
                        AccesToken = token
                    };
                }
            }
        return null;
        }

        public async Task SignUp(RegisterModel registerModel)
        {
            var user = new User
            {
                Email = registerModel.Email,
                UserName = registerModel.Email
            };

            var result = await userManager.CreateAsync(user, registerModel.Password);
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, registerModel.Role);
            }
        }
    }
}
