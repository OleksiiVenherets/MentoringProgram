using System;
using System.Threading.Tasks;
using AutorizationService.Abstract;
using AutorizationService.Models;
using MentoringProgramApplication.DataLayer.Models;
using Microsoft.AspNetCore.Identity;

namespace AutorizationService.Managers
{
    public class AutorizationManager : IAutorizationManager
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public AutorizationManager(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public async Task<IdentityResult> RegisterUser(UserModel userModel)
        {
            var user = new User
            {
                UserName = userModel.Email,
                Email = userModel.Email,
                PhoneNumber = userModel.Phone,
                City = userModel.City,
                Name = userModel.Name,
                Surname = userModel.Surname

            };

            var result = await userManager.CreateAsync(user, userModel.Password);
            if (result.Succeeded)
            {
                await signInManager.SignInAsync(user, false);
            }

            return result;
        }

        public async Task<SignInResult> LogIn(LoginModel loginModel)
        {
            return await signInManager.PasswordSignInAsync(loginModel.Email, loginModel.Password, loginModel.RememberMe, false);          
        }

        public async Task LogOff()
        {
            await signInManager.SignOutAsync();
        }
    }
}
